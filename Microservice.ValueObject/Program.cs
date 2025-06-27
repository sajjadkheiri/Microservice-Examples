using Microservice.ValueObject.Model;

var oneMeter01 = new Meter(1);
var oneMeter02 = new Meter(1);
var twoMeter01 = new Meter(2);

var oneMeter = oneMeter01 == oneMeter02;
var twoMeter = oneMeter01 == twoMeter01;

Console.WriteLine($"OneMeter: {oneMeter}");
Console.WriteLine($"TwoMeter: {twoMeter}");

Console.ReadKey();