<?php

	function getOrdersOfCustomer($userID) {
		$result = mysql_query("select * " .
							  "from orderdetails " .
							  "left join orders on orderdetails.Orders = orders.ID " .
							  "left join Product on orderdetails.Product = Product.ID " .
							  "where Customer='{$userID}';");
		if (!$result) {
			echo(mysql_error());
			exit();
		}
		return $result;
	}

	function getOrders() {
		$result = mysql_query("select * " .
							  "from orderdetails " .
							  "left join orders on orderdetails.Orders = orders.ID " .
							  "left join Product on orderdetails.Product = Product.ID " .
							  "left join customer on orders.Customer = customer.ID;");
		if (!$result) {
			echo(mysql_error());
			exit();
		}
		return $result;
	}
	
?>