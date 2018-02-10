<?php

	$id = $_GET['id'];

	deleteUser($id);
	
	$ref = $_SERVER['HTTP_REFERER'];
	header('refresh: 3; url=' . $ref);
?>