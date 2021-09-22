<?php
$conn = mysqli_connect(
  'localhost', // 주소
  'root',
  'root',
  'SSDPS');
$hashedPassword = password_hash($_POST['userpw'], PASSWORD_DEFAULT);
//echo $hashedPassword;
$sql = "
    INSERT INTO users
    (id, pw)
    VALUES('{$_POST['userid']}', '{$hashedPassword}'
    )";
//echo $sql;
$result = mysqli_query($conn, $sql);

if ($result === false) {
    echo "<script>alert('관리자에게 문의해주세요.');location.href = 'index.php';</script>";
    //echo mysqli_error($conn);
} else {
?>
    <script>
        alert("회원가입이 완료되었습니다");
        location.href = "index.php";
    </script>
<?php
}
?>