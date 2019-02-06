function CharRemover(string)
{
	var stringWithoutRepeatingLetters = "";
	var indexFirstLetter=0;
	if(!string)
	{
		string=document.getElementById("textArea").value
	}

	for(var i=0; i<string.length;i++)
	{
		while(string[i]==" "||string[i]=="\t"||string[i]=="?"||string[i]=="!"||string[i]==":"||string[i]==";"||string[i]==","||string[i]==".")
		{
			i++;
		}

		for(var j=i+1; j<string.length&&string[j]!=" "&&string[j]!="\t"&&string[j]!="?"&&string[j]!="!"&&string[j]!=":"&&string[j]!=";"&&string[j]!=","&&string[j]!="."; j++)
		{
			if(string[i] == string[j])
			{
				stringWithoutRepeatingLetters+=string.slice(indexFirstLetter, j);
				indexFirstLetter=j+1;
			}
		}
	}
	if(indexFirstLetter<string.length)
	{
		stringWithoutRepeatingLetters+=string.slice(indexFirstLetter, string.length);
	}
	console.log(stringWithoutRepeatingLetters)
	document.getElementById("textWithoutRepeatingLetters").innerHTML="<p>"+stringWithoutRepeatingLetters+"</p>";
	alert("The text without repeating characters:\n\""+stringWithoutRepeatingLetters+"\"");
}
