
#include<iostream>
#include<fstream>
#include<sstream>
#include<vector>

#include<unistd.h>

void print_usage ();

void run_dictionary_mode (std::string arg);
void run_thesaurus_mode (std::string arg, int amnt);

int main (int argc, char** argv) {
	
	if (argc < 2) {
		
		std::cout << "Invalid input, please see usage with --usage" << std::endl;
		return -1;
	}
	std::string argv1 = argv[1];
	if (argv1 == "--usage") {
		
		print_usage();
		return 0;
	}
	if (argc < 3) {
		
		std::cout << "Invalid input, please see usage with --usage" << std::endl;
		return -1;
	}
	std::string argv2 = argv[2];
	if (argv1 == "-d") {
		
		run_dictionary_mode(argv2);
		return 0;
	}
	if (argc < 4) {
		
		std::cout << "Invalid input, please enter an amount of similar words to display or see usage with --usage" << std::endl;
		return -1;
	}
	std::string argv3 = argv[3];
	int amnt = std::stoi(argv3);
	if (argv1 == "-f") {
		
		run_thesaurus_mode(argv2, amnt);
		return 0;
	}
}

void print_usage () {
	
	std::cout << "Usage for orthoget:" << std::endl;
	std::cout << " -d" << std::endl << "   Search in Dictionary mode." << std::endl;
	std::cout << " -f" << std::endl << "   Search in Thesaurus mode." << std::endl;
}

void syscom (std::string com) {
	
	system(com.c_str());
}
std::string read_file (std::string fp) {
	
	std::ifstream ifs (fp);
	std::string data, line;
	while (std::getline(ifs, line))
		data += line;
	ifs.close();
	return data;
}
std::vector<std::string> split_str (std::string s, char c) {
	
	std::stringstream ss(s);
	std::vector<std::string> vls;
	std::string val;
	while (std::getline(ss, val, c))
		vls.push_back(val);
	return vls;
}

void run_dictionary_mode (std::string arg) {

	std::cout << "Contacting Database..." << std::endl;

	syscom("wget -o cache -O get https://www.dictionary.com/browse/" + arg + "?s=t");
	
	std::string cval = read_file("cache");
	if (cval.find("404") != std::string::npos) {
	
		std::cout << "No definition found for '" << arg << "'." << std::endl;
		unlink("cache");
		unlink("get");
		return;
	}
	unlink("cache");
	
	std::string val = read_file("get");
	unlink("get");
	
	std::vector<std::string> vls0 = split_str(val, '<');
	std::vector<std::string> vls1 = split_str(vls0[9], '>');
	std::string desc = split_str(vls1[0], '\"')[3];
	
	std::cout << desc << std::endl;
}
void run_thesaurus_mode (std::string arg, int amnt) {

	std::cout << "Contacting Database..." << std::endl;

	syscom("wget -o cache -O get https://www.thesaurus.com/browse/" + arg + "?s=t");
	
	std::string cval = read_file("cache");
	if (cval.find("404") != std::string::npos) {
	
		std::cout << "No similar words found for '" << arg << "'." << std::endl;
		unlink("cache");
		unlink("get");
		return;
	}
	unlink("cache");
	
	std::string val = read_file("get");
	unlink("get");

	std::vector<std::string> vls0 = split_str(val, ',');
	
	std::vector<std::string> vls1;
	for (int i = 0; i < vls0.size(); ++i)
		if (vls0[i].find("targetTerm") != std::string::npos)
			vls1.push_back(vls0[i]);
	
	std::vector<std::string> vls2;
	for (int i = 0; i < vls1.size(); ++i)
		vls2.push_back(split_str(vls1[i], '\"')[3]);
	
	std::cout << "Similar words for " << arg << "; " << vls2[0];
	for (int i = 1; i < vls2.size(); ++i) {
		
		if (amnt-- <= 1)
			break;
		
		std::cout << ", " << vls2[i];
	}
	std::cout << std::endl;
}
