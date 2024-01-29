using GeneratorLib;

//var templateFilePath = Console.ReadLine();// @"..\templateFile.txt";
var templateFilePath =  @"..\templateFile.txt";
//var dataFilePath = Console.ReadLine();// @"..\dataFile.txt";
var dataFilePath = @"..\dataFile.txt";
//var outputFilePath = Console.ReadLine();// @"..\outputFile.txt";
var outputFilePath = @"..\outputFile.txt";
var template = File.ReadAllText(templateFilePath);
var data = File.ReadAllText(dataFilePath);
File.WriteAllText(outputFilePath, Generator.CreateHtml(template,data));




