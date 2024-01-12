<?php

class Userbase {

    private $db = null;
    public $error = false;

    public function __construct($host, $username, $password, $db) {
        try {
            $this->db = new mysqli($host, $username, $password, $db);
            $this->db->set_charset("utf8");
        } catch (Exception $exc) {
            $this->error = true;
            echo '<p>Az adatbázis nem elérhető!</p>';
            exit();
        }
    }


    public function login($name, $password) {
        $stmt = $this->db->prepare('SELECT * FROM users WHERE users.username LIKE ?;');
        $stmt->bind_param("s", $name);
    
        if ($stmt->execute()) {
            $result = $stmt->get_result();
            $row = $result->fetch_assoc();
    
            if ($row && password_verify($password, $row['password'])) {
                // Password is correct
                $_SESSION['username'] = $row['username'];
                $_SESSION['login'] = true;
            } else {
                // Incorrect password
                $_SESSION['username'] = '';
                $_SESSION['login'] = false;
            }
    
            $result->free_result();
            header("Location:index.php");
        }
    
        return false;
    }
    

    public function register($username, $password, $email) {
        $stmt = $this->db->prepare("INSERT INTO `users`( `userid` ,`username`, `password`, `email`) VALUES (NULL,?,?,?)");
        $password = password_hash($password, PASSWORD_DEFAULT);
        $stmt->bind_param("sss", $username, $password, $email);
        try {
            if ($stmt->execute()) {
                
                $_SESSION['login'] = true;
                
            } else {
                $_SESSION['login'] = false;
                echo '<p>Rögzítés sikertelen!</p>';
            }
        } catch (Exception $exc) {
            echo $exc->getTraceAsString();
        }
    }
}