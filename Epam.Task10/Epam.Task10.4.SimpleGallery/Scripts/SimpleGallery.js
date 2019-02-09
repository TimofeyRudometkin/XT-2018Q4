function showSimpleGallery(){
	var checkTimer = true;
	var count = 6;

	function timer(){
		count = document.getElementById("StopStartTimer").value == "Stop timer"
				?(count-1)
				:count;
		document.getElementById("timer").innerText = count;
		if (document.getElementById("timer").innerText <= 0)
		{
			switch (document.getElementById("blockTimer").className){
				case "firstPage":
					location.href = "SimpleGallery2.html";
					break;
				case "secondPage":
					location.href = "SimpleGallery3.html";
					break;
				case "thirdPage":
					if(confirm("Click 'OK' to go to the first page, or click 'Cancel' to close the page."))
						{
							location.href = "SimpleGallery1.html";
							break;
						}
					window.close();
					break;
			}
		}
	}
	setInterval(timer, 1000);
}

showSimpleGallery()

document.getElementById("StopStartTimer").onclick = function(){
	switch (this.value){
		case "Stop timer":
			this.value = "Start timer";
			break;
		case "Start timer":
			this.value = "Stop timer";
			break;
	}
}

document.getElementById("GoToPreviousPage").onclick = function(){
	goToPreviousPage();
}

function goToPreviousPage(){
	switch (document.getElementById("blockTimer").className){
		case "firstPage":
			location.href = "SimpleGallery3.html";
			count = 2;
			break;
		case "secondPage":
			location.href = "SimpleGallery1.html";
			count = 2
			break;
		case "thirdPage":
			location.href = "SimpleGallery2.html";
			count = 2
			break;
	}
}