<?php

	function cartSubtotal() {
		$cart = $_SESSION['cart'];

		$subtotal = 0;
		
		for($i=0; $i<count($cart); $i++) {
			$product = getProduct($cart[$i][0]);
			$row = mysql_fetch_array($product);
			$subtotal += $row["Price"];
		}
		return $subtotal;
	}
	
	function buyProducts() {
		$userID = $_SESSION['userID'];
		
		newOrder($userID);
		$order = mysql_insert_id();	
		$cart = $_SESSION['cart'];

		for($i=0; $i<count($cart); $i++) {			
			$quantity = $cart[$i][1];
			$productID = $cart[$i][0];
			addOrderDetails($order, $quantity, $productID);
		}
			
		unset($_SESSION['cart']);
	}
	
	function newOrder($userID) {
		$result = mysql_query("insert into orders(Customer, oDate) " . 
							   "values({$userID}, now());");
		if (!$result) {
			echo(mysql_error());
			exit();
		}
		return $result;
	}

	function addOrderDetails($order, $quantity, $productID) {
		$result = mysql_query("insert into orderdetails(Orders, Quantity, Product) " .
							  "values({$order}, {$quantity} , {$productID});");
		if (!$result) {
			echo(mysql_error());
			exit();
		}
		return $result;	
	}
	
?>