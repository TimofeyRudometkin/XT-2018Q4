var elementsOption = document.getElementsByClassName("<<");
for (var i=0; i<elementsOption.length; i++)
{
	elementsOption[i].onclick = function(){
		selectedItem(this);
	}
}
var elements1 = document.getElementsByClassName(">>");
for (var i=0; i<elements1.length; i++)
{
	elements1[i].onclick = function(){
		moveItemsFromLeftToRight(this);
	}
}
var elements2 = document.getElementsByClassName(">");
for (var i=0; i<elements2.length; i++)
{
	elements2[i].onclick = function(){
		moveSelectedItemsFromLeftToRight(this);
	}
}
var elements3 = document.getElementsByClassName("<");
for (var i=0; i<elements3.length; i++)
{
	elements3[i].onclick = function(){
		moveSelectedItemsFromRightToLeft(this);
	}
}
var elements4 = document.getElementsByClassName("<<");
for (var i=0; i<elements4.length; i++)
{
	elements4[i].onclick = function(){
		moveItemsFromRightToLeft(this);
	}
}

function selectedItem(element){
	
	if(element.style.background&&element.innerText)
	{
		element.style.background = "";
	}
	else if(!element.style.background&&element.innerText)
	{
		element.style.background = "rgb(163, 200, 245)";
	}
}
function moveSelectedItemsFromLeftToRight(element){

	var optionRightElement=element.parentElement.nextElementSibling.lastElementChild.firstElementChild,
		optionLeftElement=element.parentElement.previousElementSibling.lastElementChild.firstElementChild,
		checkSelect = false;

	if(optionRightElement.innerText!="")
	{
		while(optionRightElement.nextElementSibling)
		{
			optionRightElement = optionRightElement.nextElementSibling;
			if(optionRightElement.innerText=="")
			{
				break;
			}
		}
	}

	if(optionLeftElement && optionRightElement &&
	optionLeftElement.innerText!="" && optionLeftElement.style.background=="rgb(163, 200, 245)" && optionRightElement)
		{
			optionRightElement.innerText = optionLeftElement.innerText;
			optionLeftElement.innerText = "";
			optionLeftElement.style.background="";
			optionRightElement = optionRightElement.nextElementSibling;
			checkSelect = true;
		}

	while(optionLeftElement.nextElementSibling && optionRightElement)
	{
		if(optionLeftElement.nextElementSibling.innerText!="" && optionLeftElement.nextElementSibling.style.background=="rgb(163, 200, 245)")
			{
				optionRightElement.innerText = optionLeftElement.nextElementSibling.innerText;
				optionLeftElement.nextElementSibling.innerText = "";
				optionLeftElement.nextElementSibling.style.background="";
				optionRightElement = optionRightElement.nextElementSibling;
				checkSelect = true;
			}
		optionLeftElement = optionLeftElement.nextElementSibling;
	}

	optionLeftElement=element.parentElement.previousElementSibling.lastElementChild.firstElementChild;
	optionNotEmptyLeftElement = optionLeftElement.nextElementSibling;

	while(optionLeftElement)
	{
		if(optionLeftElement.innerText=="")
		{
			while(optionNotEmptyLeftElement)
			{
				if(optionNotEmptyLeftElement.innerText!="")
				{
					optionLeftElement.innerText = optionNotEmptyLeftElement.innerText;
					optionNotEmptyLeftElement.innerText = "";
					break;
				}
				optionNotEmptyLeftElement = optionNotEmptyLeftElement.nextElementSibling;
			}
		}
		optionLeftElement = optionLeftElement.nextElementSibling;
		if(optionLeftElement.nextElementSibling)
		{
			optionNotEmptyLeftElement = optionLeftElement.nextElementSibling;
		}
		else
		{
			break;
		}
	}
	if(!checkSelect)
	{
		alert("No item selected");
	}
}
function moveSelectedItemsFromRightToLeft(element){

	var optionLeftElement=element.parentElement.nextElementSibling.lastElementChild.firstElementChild,
		optionRightElement=element.parentElement.previousElementSibling.lastElementChild.firstElementChild,
		checkSelect = false;

	if(optionRightElement.innerText!="")
	{
		while(optionRightElement.nextElementSibling)
		{
			optionRightElement = optionRightElement.nextElementSibling;
			if(optionRightElement.innerText=="")
			{
				break;
			}
		}
	}

	if(optionLeftElement && optionRightElement &&
	optionLeftElement.innerText!="" && optionLeftElement.style.background=="rgb(163, 200, 245)" && optionRightElement)
		{
			optionRightElement.innerText = optionLeftElement.innerText;
			optionLeftElement.innerText = "";
			optionLeftElement.style.background="";
			optionRightElement = optionRightElement.nextElementSibling;
			checkSelect = true;
		}

	while(optionLeftElement.nextElementSibling && optionRightElement)
	{
		if(optionLeftElement.nextElementSibling.innerText!="" && optionLeftElement.nextElementSibling.style.background=="rgb(163, 200, 245)")
			{
				optionRightElement.innerText = optionLeftElement.nextElementSibling.innerText;
				optionLeftElement.nextElementSibling.innerText = "";
				optionLeftElement.nextElementSibling.style.background="";
				optionRightElement = optionRightElement.nextElementSibling;
				checkSelect = true;
			}
		optionLeftElement = optionLeftElement.nextElementSibling;
	}

	optionLeftElement=element.parentElement.nextElementSibling.lastElementChild.firstElementChild;
	optionNotEmptyLeftElement = optionLeftElement.nextElementSibling;

	while(optionLeftElement)
	{
		if(optionLeftElement.innerText=="")
		{
			while(optionNotEmptyLeftElement)
			{
				if(optionNotEmptyLeftElement.innerText!="")
				{
					optionLeftElement.innerText = optionNotEmptyLeftElement.innerText;
					optionNotEmptyLeftElement.innerText = "";
					break;
				}
				optionNotEmptyLeftElement = optionNotEmptyLeftElement.nextElementSibling;
			}
		}
		optionLeftElement = optionLeftElement.nextElementSibling;
		if(optionLeftElement.nextElementSibling)
		{
			optionNotEmptyLeftElement = optionLeftElement.nextElementSibling;
		}
		else
		{
			break;
		}
	}
	if(!checkSelect)
	{
		alert("No item selected");
	}
}
function moveItemsFromLeftToRight(element){

	var optionRightElement=element.parentElement.nextElementSibling.lastElementChild.firstElementChild,
		optionLeftElement=element.parentElement.previousElementSibling.lastElementChild.firstElementChild;

	if(optionRightElement.innerText!="")
	{
		while(optionRightElement.nextElementSibling)
		{
			optionRightElement = optionRightElement.nextElementSibling;
			if(optionRightElement.innerText=="")
			{
				break;
			}
		}
	}

	while(optionLeftElement && optionRightElement)
	{
		if(optionLeftElement.innerText!="" && optionRightElement.innerText=="")
			{
				optionRightElement.innerText = optionLeftElement.innerText;
				optionLeftElement.innerText = "";
				optionRightElement = optionRightElement.nextElementSibling;
			}
		optionLeftElement.style.background="";
		optionLeftElement = optionLeftElement.nextElementSibling;
	}

	optionLeftElement=element.parentElement.previousElementSibling.lastElementChild.firstElementChild;
	optionNotEmptyLeftElement = optionLeftElement.nextElementSibling;

	while(optionLeftElement)
	{
		if(optionLeftElement.innerText=="")
		{
			while(optionNotEmptyLeftElement)
			{
				if(optionNotEmptyLeftElement.innerText!="")
				{
					optionLeftElement.innerText = optionNotEmptyLeftElement.innerText;
					optionNotEmptyLeftElement.innerText = "";
					break;
				}
				optionNotEmptyLeftElement = optionNotEmptyLeftElement.nextElementSibling;
			}
		}
		optionLeftElement = optionLeftElement.nextElementSibling;
		if(optionLeftElement.nextElementSibling)
		{
			optionNotEmptyLeftElement = optionLeftElement.nextElementSibling;
		}
		else
		{
			break;
		}
	}
}

function moveItemsFromRightToLeft(element){

	var optionLeftElement=element.parentElement.nextElementSibling.lastElementChild.firstElementChild,
		optionRightElement=element.parentElement.previousElementSibling.lastElementChild.firstElementChild;

	if(optionRightElement.innerText!="")
	{
		while(optionRightElement.nextElementSibling)
		{
			optionRightElement = optionRightElement.nextElementSibling;
			if(optionRightElement.innerText=="")
			{
				break;
			}
		}
	}

	while(optionLeftElement && optionRightElement)
	{
		if(optionLeftElement.innerText!="" && optionRightElement.innerText=="")
			{
				optionRightElement.innerText = optionLeftElement.innerText;
				optionLeftElement.innerText = "";
				optionRightElement = optionRightElement.nextElementSibling;
			}
		optionLeftElement.style.background="";
		optionLeftElement = optionLeftElement.nextElementSibling;
	}

	optionLeftElement=element.parentElement.previousElementSibling.lastElementChild.firstElementChild;
	optionNotEmptyLeftElement = optionLeftElement.nextElementSibling;

	while(optionLeftElement)
	{
		if(optionLeftElement.innerText=="")
		{
			while(optionNotEmptyLeftElement)
			{
				if(optionNotEmptyLeftElement.innerText!="")
				{
					optionLeftElement.innerText = optionNotEmptyLeftElement.innerText;
					optionNotEmptyLeftElement.innerText = "";
					break;
				}
				optionNotEmptyLeftElement = optionNotEmptyLeftElement.nextElementSibling;
			}
		}
		optionLeftElement = optionLeftElement.nextElementSibling;
		if(optionLeftElement.nextElementSibling)
		{
			optionNotEmptyLeftElement = optionLeftElement.nextElementSibling;
		}
		else
		{
			break;
		}
	}
}