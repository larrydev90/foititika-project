
<div id="menu">
	<ul>
	<?php
		$categories = getCategories();

		while($row = mysql_fetch_array($categories)) {
	?>
		<li><a href="index.php?p=categoryProducts&q=<?php echo $row["ID"]; ?>"><?php echo $row["Name"]; ?></a></li>
	<?php
		}
	?>
	</ul>
</div>