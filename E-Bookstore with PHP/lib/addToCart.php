<?php
	session_start();

	$id = $_POST['id'];
	$quantity = $_POST['quantity'];
	// Το καλάθι είναι ένας πίνακας που κάθε στοιχείο του είναι πίνακας που περιέχει το 
	// ID του προϊόντος και την ποσότητα που έδωσε ο χρήστης
	if(!isset($_SESSION['cart'])) {
		$cartItem[0] = $id;
		$cartItem[1] = $quantity;
		$Cart[0] = $cartItem;
		$_SESSION['cart'] = $Cart;
	} else {
		$Cart = $_SESSION['cart'];
		$index = count($Cart); // Παίρνουμε το μέγεθος του πίνακα cart για να προσθέσουμε στο τέλος 
		$cartItem[0] = $id;
		$cartItem[1] = $quantity;
		$Cart[$index] = $cartItem;
		$_SESSION['cart'] = $Cart;
	}
	
	
	echo "Το καλάθι μου (" . count($Cart) . ")";
?>