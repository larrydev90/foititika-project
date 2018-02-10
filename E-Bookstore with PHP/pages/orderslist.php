<table align="center">
	<tr>
		<th>Title</th>
		<th>Quantity</th>
		<th>Date</th>
		<th>Customer</th>
	</tr>
<?php
	$orders = getOrders();
	
	while($row = mysql_fetch_array($orders)) {
?>
	<tr>
		<td><?php echo $row['Title']; ?></td>
		<td><?php echo $row['Quantity']; ?></td>
		<td><?php echo $row['oDate']; ?></td>
		<td><?php echo $row['Fname'] . " " . $row['Lname']; ?></td>
	</tr>
<?php
	}
?>
</table>