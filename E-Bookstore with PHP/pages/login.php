<?php if(!isset($_SESSION['userID'])) : ?>

<center>
<h1>Είσοδος</h1>
<br/><br/>
<form action="index.php?p=loginUser" method="post">
<table>
	<tr>
		<th>Username:</th>
		<td><input name="uname" type="text" /></td>
	</tr>
	<tr>
		<th>Password:</th>
		<td><input name="passwd" type="password" /></td>
	</tr>
	<tr style="align: center;">
       <td colspan="2"><input name="submit" type="submit" value="Login"/></td>
	</tr>
</table>
</form>
<a href="index.php?p=register">Εγγραφή Νέου Πελάτη</a>
</center>
<?php else : ?>
			<button onclick="window.location='index.php?p=logout'">Έξοδος</button>
<?php endif; ?>