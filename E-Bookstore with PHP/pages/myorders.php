<table align="center">
	<tr>
		<th>Title</th>
		<th>Quantity</th>
		<th>Date</th>
	</tr>
<?php
	$orders = getOrdersOfCustomer($_SESSION['userID']);
	
	while($row = mysql_fetch_array($orders)) {
?>
	<tr>
		<td><?php echo $row['Title']; ?></td>
		<td><?php echo $row['Quantity']; ?></td>
		<td><?php echo $row['oDate']; ?></td>
	</tr>
<?php
	}
?>
</table>