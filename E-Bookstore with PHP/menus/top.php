<?php

	if(isset($_SESSION["cart"]))
		$cartnum = "(" . count($_SESSION["cart"]) . ")";
	else
		$cartnum = "";

?>
<div id="topmenu">
	<div id="tabs">
		<ul>
			<li><a href="index.php"><span>Αρχική</span></a></li>
			<li><a href="index.php?p=shopinfo"><span>Σχετικά με το e-bookstore</span></a></li>
			<li><a href="index.php?p=products"><span>Προϊόντα</span></a></li>
			<li><a href="index.php?p=showCart"><span id="cartspan1">Το καλάθι μου <?php echo $cartnum; ?></span></a></li>
			<li><?php
					if(!isset($_SESSION["userID"])) {
				?><a href="index.php?p=login"><span>Είσοδος</span></a>
				<?php
					} else {
				?><a href="index.php?p=logout"><span onclick="logoutUser()">Έξοδος</span></a>
				<?php
					}
				?>
			</li>
			<li><a href="index.php?p=contact"><span>Επικοινωνία</span></a></li>  
		</ul>
	</div>
</div>