<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Formulario_Empresa.aspx.cs" Inherits="Turismo_Pagina.paginas.Formulario_Empresa" %>

<!DOCTYPE html>
<!--[if lt IE 7]>      <html class="no-js lt-ie9 lt-ie8 lt-ie7"> <![endif]-->
<!--[if IE 7]>         <html class="no-js lt-ie9 lt-ie8"> <![endif]-->
<!--[if IE 8]>         <html class="no-js lt-ie9"> <![endif]-->
<!--[if gt IE 8]><!-->
<html class="no-js">
<!--<![endif]-->
<head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <title>Turismo Guatemala - Registrar Empresa</title>
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="description" content="Página para conocer el turismo" />
    <meta name="keywords" content="Turismo Guatemala" />
    <meta name="author" content="Luis Fernando Arana Arias" />



    <!-- Facebook and Twitter integration -->
    <meta property="og:title" content="" />
    <meta property="og:image" content="" />
    <meta property="og:url" content="" />
    <meta property="og:site_name" content="" />
    <meta property="og:description" content="" />
    <meta name="twitter:title" content="" />
    <meta name="twitter:image" content="" />
    <meta name="twitter:url" content="" />
    <meta name="twitter:card" content="" />

    <!-- Place favicon.ico and apple-touch-icon.png in the root directory -->
    <link rel="shortcut icon" href="favicon.ico">

    <!-- <link href='https://fonts.googleapis.com/css?family=Open+Sans:400,700,300' rel='stylesheet' type='text/css'> -->

    <!-- Animate.css -->
    <link rel="stylesheet" href="/css/animate.css">
    <!-- Icomoon Icon Fonts-->
    <link rel="stylesheet" href="/css/icomoon.css">
    <!-- Bootstrap  -->
    <link rel="stylesheet" href="/css/bootstrap.css">
    <!-- Superfish -->
    <link rel="stylesheet" href="/css/superfish.css">

    <link rel="stylesheet" href="/css/style.css">


    <!-- Modernizr JS -->
    <script src="/js/modernizr-2.6.2.min.js"></script>
    <!-- FOR IE9 below -->
    <!--[if lt IE 9]>
	<script src="js/respond.min.js"></script>
	<![endif]-->

</head>
<body>
    <div id="fh5co-wrapper">
        <div id="fh5co-page">
            <div id="fh5co-header">
                <header id="fh5co-header-section">
                    <div class="container">
                        <div class="nav-header">
                            <a href="#" class="js-fh5co-nav-toggle fh5co-nav-toggle"><i></i></a>
                            <h1 id="fh5co-logo"><a href="Index.aspx">Turismo Guatemala</a></h1>
                            <!-- START #fh5co-menu-wrap -->
                            <nav id="fh5co-menu-wrap" role="navigation">
                                <ul class="sf-menu" id="fh5co-primary-menu">
                                    <li>
                                        <a href="index.aspx">Home</a>
                                    </li>

                                    <li>
                                                                                <a href="Catalogo.aspx">Ver Catálogo</a>                                        
                                      
                                    </li>

                                    <li class="active">
                                        <a href="Formulario_Empresa.aspx">Registrar Empresa</a>
                                    </li>

                                    <li>
                                        <!-- Cambiar referencia a iniciar sesion -->
                                        <a href="LogIn.aspx" class="fh5co-sub-ddown">Iniciar Sesión</a>
                                    </li>
                                     <li>                                
                                        <a href="Registro_Publico.aspx" class="fh5co-sub-ddown">Registrarse</a>
                                    </li>
                                </ul>
                            </nav>
                        </div>
                    </div>
                </header>

            </div>
            <br />
            <br />
            <br />

            <div id="fh5co-contact" class="fh5co-section animate-box">
                <div class="container">
                    <form method="post" runat="server" action="#" class="mostrardatos">
                        <div class="row">
                            <div class="col-md-6">
                                <h3 class="section-title">Llenar formulario de Empresa</h3>
                                <ul>
                                    <li>
                                        <a>Nombre*:</a>
                                        <asp:TextBox ID="nombre" placeholder="Nombre" runat="server" class="cajaTexto"></asp:TextBox>
                                    </li>
                                    <li>
                                        <a>Dirección*:</a>
                                        <asp:TextBox ID="direccion" placeholder="Dirección" runat="server" class="cajaTexto"></asp:TextBox>
                                    </li>
                                    <li>
                                        <a>Teléfono:</a>
                                        <asp:TextBox ID="telefono" placeholder="Teléfono" runat="server" class="cajaTexto"></asp:TextBox>
                                    </li>
                                    <li>
                                        <a>Correo:</a>
                                        <asp:TextBox ID="correo" placeholder="Correo" runat="server" class="cajaTexto"></asp:TextBox>
                                    </li>
                                    <li>
                                        <a>Tipo de Empresa*:</a>
                                        <asp:DropDownList ID="listTipo" runat="server" CssClass="listaRegion" AutoPostBack="true" OnSelectedIndexChanged="listTipo_SelectedIndexChanged">
                                            <asp:ListItem>Museo</asp:ListItem>
                                            <asp:ListItem>Restaurante</asp:ListItem>
                                            <asp:ListItem>Hotel</asp:ListItem>
                                        </asp:DropDownList>
                                    </li>
                                    <br />
                                    <li>
                                        <a>Región*:</a>
                                        <asp:DropDownList ID="listRegion" runat="server" CssClass="listaRegion">
                                            <asp:ListItem>Norte</asp:ListItem>
                                            <asp:ListItem>Sur</asp:ListItem>
                                            <asp:ListItem>Este</asp:ListItem>
                                            <asp:ListItem>Oeste</asp:ListItem>
                                        </asp:DropDownList>
                                    </li>
                                    <br />
                                    <li>
                                        <asp:FileUpload ID="cargaFoto" runat="server" accept=".jpg"  CssClass ="form-control"/>
                                    </li>
                                </ul>
                                <asp:Button ID="boton" runat="server" Text="Registrar" class="boton" OnClick="boton_Click" />
                                <asp:Label ID="mensaje" runat="server" Text="" CssClass="mensaje"></asp:Label>
                            </div>
                            <div class="col-md-6">
                                <div class="row">
                                    <h3 class="section-title">Se mostrara dependiendo la seleccion del Tipo de Empresa</h3>
                                    <ul>
                                        <li id="Plato">
                                            <a>Especialidades*:</a>                                            
                                            <asp:CheckBoxList ID="listEspecialidades" runat="server">                                                
                                            </asp:CheckBoxList>                                                                                        
                                        </li>
                                        <li>
                                            <a>Servicios*:</a>
                                            <asp:CheckBoxList ID="listServicios" runat="server">                                               
                                            </asp:CheckBoxList>
                                        </li>
                                        <li>
                                            <a>Horario*:</a>
                                            <asp:TextBox ID="horario" placeholder="Horario" runat="server" class="cajaTexto" Enabled="false"></asp:TextBox>
                                        </li>
                                        <li>
                                            <a>Tarifa*:</a>
                                            <asp:TextBox ID="tarifa" placeholder="Tarifa" runat="server" class="cajaTexto" Enabled="false"></asp:TextBox>
                                        </li>
                                    </ul>
                                </div>
                            </div>
                        </div>
                    </form>
                </div>
            </div>


            <footer>
                <div id="footer">
                    <div class="container">
                        <div class="row">
                            <div class="col-md-6 col-md-offset-3 text-center">
                                <p class="fh5co-social-icons">
                                    <a href="#"><i class="icon-twitter2"></i></a>
                                    <a href="#"><i class="icon-facebook2"></i></a>
                                    <a href="#"><i class="icon-instagram"></i></a>
                                    <a href="#"><i class="icon-dribbble2"></i></a>
                                    <a href="#"><i class="icon-youtube"></i></a>
                                </p>
                                <p>
                                    Copyright 2019 <a href="Index.aspx">Turismo Guatemala</a>. All Rights Reserved.
                                        <br>
                                    Made with <i class="icon-heart3"></i>by <a href="s" target="_blank">Luis Arana</a> / Demo Images: <a href="https://google.com/" target="_blank">Google</a>
                                </p>
                            </div>
                        </div>
                    </div>
                </div>
            </footer>


        </div>
        <!-- END fh5co-page -->

    </div>
    <!-- END fh5co-wrapper -->

    <!-- jQuery -->


    <script src="/js/jquery.min.js"></script>
    <!-- jQuery Easing -->
    <script src="/js/jquery.easing.1.3.js"></script>
    <!-- Bootstrap -->
    <script src="/js/bootstrap.min.js"></script>
    <!-- Waypoints -->
    <script src="/js/jquery.waypoints.min.js"></script>
    <!-- Stellar -->
    <script src="/js/jquery.stellar.min.js"></script>
    <!-- Superfish -->
    <script src="/js/hoverIntent.js"></script>
    <script src="/js/superfish.js"></script>

    <!-- Main JS -->
    <script src="/js/main.js"></script>
</body>
</html>
