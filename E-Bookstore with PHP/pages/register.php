<?php

	if(isset($_POST['submit'])) {
		$fname	 = $_POST['fname'];
		$lname	 = $_POST['lname'];
		$address = $_POST['address'];
		$phone	 = $_POST['phone'];
		$uname	 = $_POST['uname'];
		$passwd	 = $_POST['passwd'];

		insertUser($fname, $lname, $address, $phone, $uname, $passwd);
		
		echo "User created!";
		$ref = $_SERVER['HTTP_REFERER'];
		header('refresh: 3; url=' . $ref);
	} else {
?>
<form action="index.php?p=register" method="post">
	<fieldset>
		<legend>Register</legend>
		<label for="fname">Name:</label>
		<input type="text" name="fname" /><br />
		<label>Surname:</label>
		<input type="text" name="lname" /><br />
		<label>Address:</label>
		<input type="text" name="address" /><br />
		<label>Phone:</label>
		<input type="text" name="phone" /><br />
		<label>Username:</label>
		<input type="text" name="uname" /><br />
		<label>Password:</label>
		<input type="password" name="passwd" /><br />
		<input type="submit" name="submit" value="Register" />
	</fieldset>
</form>
<?php
	}
?>