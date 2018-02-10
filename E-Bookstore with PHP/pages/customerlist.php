<table align="center">
	<tr>
		<th>Fname</th>
		<th>Lname</th>
		<th>Address</th>
		<th>Phone</th>
		<th>Delete</th>
	</tr>
<?php
	$users = getUsers();
	   
	while($row = mysql_fetch_array($users)) {
?>
	<tr>
		<td><?php echo $row['Fname']; ?></td>
		<td><?php echo $row['Lname']; ?></td>
		<td><?php echo $row['Address']; ?></td>
		<td><?php echo $row['Phone']; ?></td>
		<td><a href="index.php?p=deletecust&id=<?php echo $row['ID']; ?>"><button>Delete</button></a><td>
	</tr>
<?php
	}
?>
</table>