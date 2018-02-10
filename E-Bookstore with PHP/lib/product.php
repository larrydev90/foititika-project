<?php
// Functions που υλοποιούν queries που αφορούν τα προϊόντα 
	function getProduct($id) {
		$result = mysql_query("select * " .
							  "from Product " . 
							  "where ID = {$id};");
		if (!$result) {
			echo(mysql_error());
			exit();
		}
		return $result;	// Επιστρέφει τον πίνακα των αποτελεσμάτων
	}

	function getProducts() {
		$result = mysql_query("select * " .
							  "from Product;");
		if (!$result) {
			echo(mysql_error());
			exit();
		}
		return $result; // Επιστρέφει τον πίνακα των αποτελεσμάτων
	}
	
	function getProductsFromCategory($category) {
		$result = mysql_query("select * " .
							  "from Product ".
							  " where Category =".$category);
		if (!$result) {
			echo(mysql_error());
			exit();
		}
		return $result; // Επιστρέφει τον πίνακα των αποτελεσμάτων
	}
	
?>