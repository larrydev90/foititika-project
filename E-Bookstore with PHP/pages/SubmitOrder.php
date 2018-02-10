<?php

	if(isset($_SESSION['userID'])) {
		buyProducts();
		header('Location: index.php');
	} else {
		header('Location: index.php?p=login');
	}

?>