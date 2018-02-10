var xmlHttp;

function addProduct() {

	if (window.XMLHttpRequest) { 
		// code for IE7+, Firefox, Chrome, Opera, Safari 
		xmlHttp = new XMLHttpRequest(); 
	} else {  
		// code for IE6, IE5 
		xmlHttp = new ActiveXObject("Microsoft.XMLHTTP"); 
	}
	xmlHttp.onreadystatechange = changeCartLabel;
	
	var url = "lib/addToCart.php";
	// Αποστολή με Post
	xmlHttp.open("POST", url, false);
	xmlHttp.setRequestHeader("Content-type","application/x-www-form-urlencoded");
	var var1 = document.getElementById("prodID").value;
	var var2 = document.getElementById("prodQuant").value;
	xmlHttp.send("id=" + var1 + "&quantity=" +  var2);
}

function changeCartLabel() {
		if (xmlHttp.readyState == 4) {
			if (xmlHttp.status == 200) {
				console.log(xmlHttp.responseText); // γράφει το αποτέλεσμα στο log για λόγους debugging
				document.getElementById("cartspan1").innerHTML = xmlHttp.responseText;
			}
		}
}