<table>
	<tr>
		<th>Τίτλος</th>
		<th>Περιγραφή</th>
		<th>Τιμή</th>
		<th>Προσότητα</th>
		<th>Προσθήκη</th>
	</tr>
<?php
	$id = $_GET['q']; 
	$products = getProduct($id);
	
	while($row = mysql_fetch_array($products)) {
?>
	<tr>
		<td><?php echo $row["Title"]; ?></td>
		<td><?php echo $row["Description"]; ?></td>
		<td><?php echo $row["Price"]; ?></td>
		<input type="hidden" id="prodID" name="id" value="<?php echo $row["ID"]; ?>" />
		<td><input type="text" id="prodQuant" value="1" name="quantity" /></td>
		<td><input type="button" value="Προσθήκη" onclick="addProduct()" /></td>
	</tr>
<?php
	}	
?>
</table>