<?php

function validSzig($param) {
    $pattern = "/[1-9]{1}[0-9]{5}[A-Za-z]{2}/";
    return preg_match($pattern, $param);
}

if (filter_input(INPUT_POST, "regisztraciosAdatok", FILTER_VALIDATE_BOOLEAN, FILTER_NULL_ON_FAILURE)) {
    $error = false;
    $errormessage = "";
    $pass1 = filter_input(INPUT_POST, "InputPassword");
    $pass2 = filter_input(INPUT_POST, "InputPassword2");
    $username = htmlspecialchars(filter_input(INPUT_POST, "username"));
    $email = filter_input(INPUT_POST, "useremail", FILTER_VALIDATE_EMAIL);
    if ($pass1 != $pass2) {
        $error = true;
        $errormessage .= '<p>Nem egyeznek a jelszavak!</p>';
    } else if ($username == null) {
        $error = true;
        $errormessage .= '<p>Nem megfelelő felhasználónév</p>';
    }
    if ($error) {
        echo $errormessage;
    } else {
        $db->register($username, $pass1, $email);
        header("Location:index.php");
    }
}
?>
<section class="h-100 gradient-form bg-login-img" >
  <div class="container py-5 h-100">
    <div class="row d-flex justify-content-center align-items-center h-100">
      <div class="col-xl-10">
        <div class="card rounded-3 border border-0 text-black">
          <div class="row g-0">
          <div class="col-lg-6 d-flex align-items-center gradient-custom-2">
              <div class="text-white px-3 py-4 p-md-5 mx-md-4">
                <h1>Mystic Realm</h1>
                <h4 class="mb-4">Embark on an Epic Fantasy Adventure"</h4>
                <p class="small mb-0">Mystic Realm is a cutting-edge MMORPG that immerses players in a mesmerizing world of magic, mystery, and mayhem. Set in a sprawling fantasy realm filled with ancient legends and mythical creatures, players are tasked with the monumental quest of saving the land from an encroaching darkness.</p>
              </div>
            </div>
            <div class="col-lg-6">
              <div class="card-body p-md-5 mx-md-4">
                
                <div class="text-center">
                  <img src="./Img/logo.png" alt="logo">
                  <h4 class="mt-1 mb-5 pb-1">Mystic Realm</h4>
                </div>

                <form action="#" method="post">

                  <div class="form-outline mb-4">
                    <input type="text" id="username" name="username" aria-describedby="emailHelp" class="form-control" required />
                    <label class="form-label" for="username">Username</label>
                  </div>
               
                  <div class="form-outline mb-4">
                    <input type="password" id="InputPassword"  name="InputPassword" class="form-control" required/>
                    <label class="form-label" for="InputPassword">Password</label>
                  </div>
                  <div class="form-outline mb-4">
                    <input type="password" id="InputPassword2"  name="InputPassword2" class="form-control" required/>
                    <label class="form-label" for="InputPassword2">Password Again</label>
                  </div>
                  <div class="form-outline mb-4">
                    <input type="email" id="useremail"  name="useremail" class="form-control"required />
                    <label class="form-label" for="useremail">Emails</label>
                  </div>

                  <div class="text-center pt-1 mb-5 pb-1">
                    <button class="btn btn-outline-primary w-50" type="submit" name="regisztraciosAdatok" value="true">Registration</button>
                  </div>

                  <div class="d-flex align-items-center justify-content-center pb-4">
                    <p class="mb-0 me-2">Already had account?</p>
                    <a href="index.php?login_register_switch=logins" class="btn btn-outline-primary">Logins</a>
                  </div>

                </form>

              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</section>
<script>
    var passwordInputs = document.querySelectorAll("input[type=password]");
    function validPass(password) {
        console.log(password);
        let theLength = /.{6,32}/;
        let lowerCase = /[a-z]/;
        let upperCase = /[A-Z]/;
        let digit = /[0-9]/;
        let specialChars = /^[a-zA-Z0-9]/;
        if (theLength.test(password) &&
                lowerCase.test(password) &&
                upperCase.test(password) &&
                digit.test(password) &&
                specialChars.test(password)) {
            return true;
        } else {
            return false;
        }
    }

    function passStrength(password) {
        let strength = password.length;

    }

</script>