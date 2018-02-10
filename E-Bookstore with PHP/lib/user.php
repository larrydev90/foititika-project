<?php
// Συναρτήσεις για την Διαχείριση Χρηστών
	function loginUser($username, $password) {
		if(($username == "admin") && ($password == "1234")) {
			$_SESSION['userID'] = 0;
			return true;
		} else {
			$result = mysql_query("select * " .
								  "from customer " .
								  "where uname = '$username' and ".
								  "passwd = '$password';");
			$rows = mysql_num_rows($result);

			if($rows == 1) {
				$row = mysql_fetch_array($result);
				$_SESSION['userID'] = $row['ID'];
				return true;
			} else {
				return false;
			}
		}
	}

	function logoutUser() {
		unset($_SESSION['userID']);
	}

	function getUser() {
		$userID = $_SESSION['userID'];
	
		$result = mysql_query("select * " . 
							  "from customer ".
							  "where ID = {$userID};");
		if (!$result) {
			echo(mysql_error());
			exit();
		}
		return $result;
	}
	
	function getUsers() {
		$result = mysql_query("select * " . 
							  "from customer;");
		if (!$result) {
			echo(mysql_error());
			exit();
		}
		return $result;
	}

	function insertUser($fname, $lname, $address, $phone, $uname, $passwd) {
		$result = mysql_query("insert into customer " .
							  "set Fname = '$fname', " .
								  "Lname = '$lname', " .
								  "Address = '$address', " .
								  "Phone = '$phone', " .
								  "uname = '$uname', " .
								  "passwd = '$passwd';");
		if (!$result) {
			echo(mysql_error());
			exit();
		}	
		return $result;		
	}
	
	function updateUser($id, $fname, $lname, $address, $phone, $uname, $passwd) {
		$result = mysql_query("update customer " .
							  "set Fname = '$fname', " .
								  "Lname = '$lname', " .
								  "Address = '$address', " .
								  "Phone = '$phone', " .
								  "uname = '$uname', " .
								  "passwd = '$passwd' " .
							  "where ID = $id;");
		if (!$result) {
			echo(mysql_error());
			exit();
		}
		return $result;	
	}

	function deleteUser($id) {
		$result = mysql_query("delete from Customer " .
							  "where ID = {$id};");
		if (!$result) {
			echo(mysql_error());
			exit();
		}
		return $result;
	}

?>