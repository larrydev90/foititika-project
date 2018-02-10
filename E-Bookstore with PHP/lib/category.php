<?php

	function getCategories() {
		$result = mysql_query("select * " .
							  "from category;");
		if (!$result) {
			echo(mysql_error());
			exit();
		}
		return $result;
	}

?>