<?php
	$found = loginUser($_POST['uname'], $_POST['passwd']);
	if($found)
		echo '<h1>Καλώς Ήρθατε</h1>';
	else {
	   	  echo '<h1>Λάθος Username ή Password</h1>';
		  echo "<button onclick=\"window.location='index.php?p=login'\">Προσπαθήστε ξανά</button>";
	}	

?>