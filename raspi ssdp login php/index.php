<!DOCTYPE html>
<?php session_start(); ?>
<?php
$conn = mysqli_connect(
  'localhost', // 주소
  'root',
  'root',
  'SSDPS');
?>
<html>
	<head>
		<meta charset="utf-8"/>
		<title>UUID Setting</title>
		 <!-- jQuery  -->
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    <!-- Bootstrap -->
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.0-beta1/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-giJF6kkoqNQ00vy+HMDP7azOuL0xtbfIcaT9wjKHr8RbDVddVHyTfAAsrekwKmP1" crossorigin="anonymous">
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.0-beta1/dist/js/bootstrap.bundle.min.js" integrity="sha384-ygbV9kiqUc6oa4msXn9868pTtWMgiQaeYH7/t7LECLbyPA2x65Kgf80OJFdroafW" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/@popperjs/core@2.5.4/dist/umd/popper.min.js" integrity="sha384-q2kxQ16AaE6UbzuKqyBE9/u/KzioAlnx2maXQHiDX9d4/zp8Ok3f+M7DPm+Ib6IU" crossorigin="anonymous"></script>    
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.0-beta1/dist/js/bootstrap.min.js" integrity="sha384-pQQkAEnwaBkjpqZ8RU1fF1AKtTcHJwFl3pblpTlHXybJjHpMYo79HY3hIi4NKxyj" crossorigin="anonymous"></script>
    <style>
html, body
{
    height: 100%;
}

body
{
    display: table;
    margin: 0 auto;
    animation: fadein 2s;
    -webkit-animation: fadein 2s; /* Safari and Chrome */
}

.container
{
    height: 100%;
    display: table-cell;
    vertical-align: middle;
}

.main
{
    height: 400px;
    width: 600px;
}
@-webkit-keyframes fadein { /* Safari and Chrome */
    from {
        opacity:0;
    }
    to {~
        opacity:1;
    }
}
</style>
</head>
		<body>
			<br>
				<?php
            if(!isset($_SESSION['user_id'])) {
				echo "<script>location.href='login.php';</script>";
            } else {
                $user_id = $_SESSION['user_id'];
                echo "<p><strong>$user_id</strong>님 환영합니다.";
                echo "<a href=\"logout.php\">[로그아웃]</a></p>";
				echo "<div class='row'>";
				echo "<div class='col-sm-6'>";
				echo "<div class='input-group'>";
				echo "<input id='uuid_input' type='text' class='form-control' placeholder='UUID' size=80 maxlength=50 required>";
				echo "<span class='input-group-btn'>";
				echo "&nbsp;<button class='btn btn-outline-dark' type='button'>등록</button>";
				echo "</span>";
				echo "</div>";
				echo "</div>";
				echo "</div><br>";
				echo "<table id='result_table' width='100%' class='table table-striped table-bordered table-hover'>";
				echo "<thead>";
				echo "<tr>";
				echo "<th>No.</th>";
				echo "<th>UUID</th>";
				echo "</tr>";
				echo "</thead>";
				echo "<tbody>";
				$sql = "SELECT * FROM device";
				$result = mysqli_query($conn, $sql);
				while($row = mysqli_fetch_array($result)) {
					echo "<tr><td>".$row['no']."</td><td>".$row['uuid']."</td></tr>";
				}
				echo "</tbody>";
				echo "</table>";
            }
			mysqli_close($conn);
        ?>
		    <script>
			
			$("#uuid_input").keydown(function(key) {

				if (key.keyCode == 13) {

            if($('#uuid_input').val()=='')  {
                  $('#uuid_input').focus();
            }else{
				var str = $('#uuid_input').val();
				var uid = '<?php echo $user_id ;?>';
				$.post("uuidreg.php", {uid: uid,user_uuid: str},function(data){
					if(data == '0'){
						alert("정보를 불러올수없습니다.");
					}else{
						location.reload();
					}
				}); 
			}

				}

			});
			
			
			
			$('button').click(function() {
				
            if($('#uuid_input').val()=='')  {
                  $('#uuid_input').focus();
            }else{
				var str = $('#uuid_input').val();
				var uid = '<?php echo $user_id ;?>';
				$.post("uuidreg.php", {uid: uid,user_uuid: str},function(data){
					if(data == '0'){
						alert("정보를 불러올수없습니다.");
					}else{
						location.reload();
					}
				}); 
			}
			
				
			});

$("#result_table tr").click(function() {

    var tr = $(this);
    var td = tr.children();
    var no = td.eq(0).text();
    var uuid = td.eq(1).text();

    var pattern1 = /[0-9]/;
    var pattern2 = /[a-zA-Z]/;
   

    if (pattern1.test(uuid) && pattern2.test(uuid)) {

        var result = confirm(uuid + " 를 삭제하시겠습니까?");

        if (result) {
        var uid = '<?php echo $user_id ;?>';
				$.post("uuiddel.php", {uid: uid,user_uuid: uuid},function(data){
					if(data == '0'){
						alert("정보를 불러올수없습니다.");
						location.reload();
					}else{
						location.reload();
					}
		});
        }

    }

});
    
    </script>
	
    </body>
</html>
