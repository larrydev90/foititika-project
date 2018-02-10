<?php

	function connectToDB() {
		$server	  = "localhost";
		$username = "root";
		$password = "";
		$dbName   = "ebookstoreDB"; 
		
		$dbConnection = mysql_connect("$server", "$username", "$password");
		if(!$dbConnection) {
			die("<p>Could not connect to server: "  . mysql_error() . "</p>");
		}
		
		$dbSelection = mysql_select_db("$dbName", $dbConnection);
		if(!$dbSelection) {
			die("<p>Could not select database: " . mysql_error() . "</p>");
		}
		
		return $dbConnection;
	}

?>