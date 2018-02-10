<?php

	$id 	 = $_POST['id'];
	$fname	 = $_POST['fname'];
	$lname	 = $_POST['lname'];
	$address = $_POST['address'];
	$phone	 = $_POST['phone'];
	$uname	 = $_POST['uname'];
	$passwd	 = $_POST['passwd'];

	updateUser($id, $fname, $lname, $address, $phone, $uname, $passwd);
	$ref = $_SERVER['HTTP_REFERER'];
	header('refresh: 3; url=' . $ref);

?>