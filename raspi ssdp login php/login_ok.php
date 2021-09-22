<?php
$conn = mysqli_connect(
  'localhost',
  'root',
  'root',
  'SSDPS');
    if ( !isset($_POST['user_id']) || !isset($_POST['user_pw']) ) {
        header("Content-Type: text/html; charset=UTF-8");
        echo "<script>alert('아이디 또는 비밀번호가 빠졌거나 잘못된 접근입니다.');";
        echo "window.location.replace('login.php');</script>";
        exit;
    }
	$user_id = $_POST['user_id'];
	$user_pw = $_POST['user_pw'];
	
	$sql = "SELECT * FROM users WHERE id ='{$user_id}'";
	$result = mysqli_query($conn, $sql);
	$row = mysqli_fetch_array($result);
	$hashedPassword = $row['pw'];

	$passwordResult = password_verify($user_pw, $hashedPassword);
if ($passwordResult === true) {
    session_start();
    $_SESSION['user_id'] = $row['id'];
    
?>
    <script>
        location.href = "index.php";
    </script>
<?php
} else {
?>
    <script>
	  alert("아이디 또는 패스워드를 확인해주세요!")
      location.href = "login.php";
    </script>
<?php
}
?>