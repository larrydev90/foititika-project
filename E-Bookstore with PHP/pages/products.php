﻿<table align="center">
	<tr>
		<th>Τίτλος</th>
		<th>Τιμή</th>
	</tr>
<?php
	$products = getProducts();
	
	while($row = mysql_fetch_array($products)) {
?>
	<tr>
		<td><a href="index.php?p=productDesc&q=<?php echo $row["ID"]; ?>"><?php echo $row["Title"]; ?></a></td>
		<td><?php echo $row["Price"]; ?></td>
	</tr>
<?php
	}
?>
</table>