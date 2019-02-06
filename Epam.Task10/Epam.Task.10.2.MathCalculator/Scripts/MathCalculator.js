function MathCalculator(expression)
{
	if(!expression)
		{
			expression=document.getElementById("textArea").value
		}

	var regexpNumbers = /[0-9]+([.][0-9]*)?/g;
	var regexOperators = /[\+\-\*\/]/g;
	 
	var arrayNumbers = expression.match(regexpNumbers);
	var arrayOperators = expression.match(regexOperators)
	
	var number = +arrayNumbers[0];

	for(i=0; i<arrayOperators.length; i++)
	{
		switch (arrayOperators[i])
		{
			case "+":
				number += +arrayNumbers[i+1];
				break;
			case "-":
				number -= arrayNumbers[i+1];
				break;
			case "*":
				number *= arrayNumbers[i+1];
				break;
			case "/":
				number /= arrayNumbers[i+1];
				break;
		}
	}
	alert(Math.round(number*100)/100);
}