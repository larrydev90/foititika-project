<?php
   // Γίνεται έλεγχος εάν υπάρχει στο URL η deleteCart και αν υπάρχει τότε διαγράφει από το Session το cart
   if (isset($_GET['deleteCart'])) 
      unset($_SESSION['cart']);
   
   // Εδώ ελέγχουμε εάν υπάρχει cart και το εμφανίζουμε και εάν δεν υπάρχει εμφανίζουμε σχετικό μήνυμα
   if(isset($_SESSION['cart'])) :
?>
<form method="post" action="index.php?p=submitOrder">
<table align="center">
	<tr>
		<th>Τιτλός</th>
		<th>Ποσότητα</th>
	</tr>
	<?php
		$subtotal = cartSubtotal();// function της lib/cart.php
		
		$cart = $_SESSION['cart'];
		
		for($i=0; $i<count($cart); $i++) {
			$product = getProduct($cart[$i][0]); // function της lib/product.php
			$row = mysql_fetch_array($product);
	?>
	<tr>
		<td><?php echo $row["Title"]; ?></td>	
		<td><?php echo $cart[$i][1]; ?></td>
	</tr>
<?php
		}	
?>
	<tr>
		<td colspan="2">Σύνολο: <?php echo $subtotal; ?></td>
	<tr>
	<tr>
		<td><input type="submit" value="Αγορά" /></td>

		<!-- To παρακάτω κουμπί θα καλέσει με JS την ίδια την σελίδα περνόντας ως παράμετρο την deleteCart 
		     για να διαγραφεί το καλάθι -->
		<td><input type="button" value="Άδειασμα Καλαθιού" onclick="window.location='index.php?p=showCart&deleteCart=1'"/></td>
	</tr>
</table>
</form>
<?php	else : ?>
		<h1>Το Καλάθι σας είναι άδειο</h1>
<?php	endif; ?>