<nav class="navbar navbar-expand-lg bg-body-tertiary nav-bg-color" data-bs-theme="dark">
    <div class="container-fluid">
        <img src="./img/logo.png" alt="Logo" width="30" height="24" class="d-inline-block ">
        <a class="navbar-brand" href="#">Mystic Realm</a>
        <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
        <span class="navbar-toggler-icon"></span>
        </button>
        <div class="collapse navbar-collapse" id="navbarSupportedContent">
            <ul class="navbar-nav me-auto mb-2 mb-lg-0">
                <?php
                    echo '<li class="nav-item">
                    <a class="nav-link' . ($navbardswitch == 'home' ? ' active' : ''). '"aria-current="page" href="index.php?nav=home">Home</a>
                    </li>
                    <li class="nav-item dropdown">
                        <a class="nav-link dropdown-toggle" href="#" role="button" data-bs-toggle="dropdown" aria-expanded="false">
                            Explore
                        </a>
                        <ul class="dropdown-menu">
                            <li>
                            <a class="dropdown-item' . ($navbardswitch == 'lore' ? ' active' : ''). '"aria-current="page" href="index.php?nav=lore">Lore</a>
                            </li>
                            <li>
                            <a class="dropdown-item' . ($navbardswitch == 'game' ? ' active' : ''). '"aria-current="page" href="index.php?nav=game">Game</a>
                            </li>
                            <li>
                            <a class="dropdown-item' . ($navbardswitch == 'items' ? ' active' : ''). '"aria-current="page" href="index.php?nav=items">Items</a>
                            </li>
                            <li>
                            <a class="dropdown-item' . ($navbardswitch == 'monster' ? ' active' : ''). '"aria-current="page" href="index.php?nav=monster">Monster</a>
                            </li>
                            <li>
                            <a class="dropdown-item' . ($navbardswitch == 'skills' ? ' active' : ''). '"aria-current="page" href="index.php?nav=skills">Skills</a>
                            </li>
                        </ul>
                    </li>
                    <li class="nav-item">
                    <a class="nav-link' . ($navbardswitch == 'logout' ? ' active' : ''). '"aria-current="page" href="index.php?nav=logout">Logout</a>
                    </li>';
                ?>
            </ul>
        </div>
    </div>
</nav>