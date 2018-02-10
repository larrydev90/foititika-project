<?php

	$user = getUser();
	$row = mysql_fetch_array($user);

?>
<form action="index.php?p=changecust" method="post">
	<fieldset>
		<legend>Στοιχεία Πελάτη</legend>
		<!-- χρήση του hidden field για να την διατήρηση μία τιμή την οποία θα επανα-υποβάλουμε
		     όταν θα γίνει η υποβολή της φόρμας -->
		<input type="hidden" name="id" value="<?php echo $row['ID']; ?>" />
		<label for="fname">Όνομα:</label>
		<input type="text" name="fname" value="<?php echo $row['Fname']; ?>" /><br />
		<label>Επώνυμο:</label>
		<input type="text" name="lname" value="<?php echo $row['Lname']; ?>" /><br />
		<label>Διεύθυνση:</label>
		<input type="text" name="address" value="<?php echo $row['Address']; ?>" /><br />
		<label>Τηλέφωνο:</label>
		<input type="text" name="phone" value="<?php echo $row['Phone']; ?>" /><br />
		<label>Username:</label>
		<input type="text" name="uname" value="<?php echo $row['uname']; ?>" /><br />
		<label>Password:</label>
		<input type="password" name="passwd" value="<?php echo $row['passwd']; ?>" /><br />
		<input type="submit" value="Αλλαγή Στοιχείων" />
	</fieldset>
</form>