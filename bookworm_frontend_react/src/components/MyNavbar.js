import React, { useState } from "react";
import { Navbar, Nav, NavDropdown, Button } from "react-bootstrap";
import { Link, useNavigate } from "react-router-dom";
import {
  FaHome,
  FaProductHunt,
  FaBook,
  FaCartPlus,
  FaLayerGroup,
  FaBookReader,
  FaUserCircle,
  FaInfoCircle,
  FaPhone,
  FaComments,
  FaSignInAlt,
} from "react-icons/fa";
import { useCookies } from "react-cookie";
import "../css/MyNavbar.css";
import config from '../config.json';

export default function MyNavbar() {
  const [cookies, setCookie] = useCookies(["user"]);
  const navigate = useNavigate();

  const [open, setOpen] = useState(false);

  const handleOpen = () => setOpen(!open);
  const handleClose = () => setOpen(false);

  const handlelogout = () => {
    fetch(`http://localhost:${config.port}/api/customer/logout`).then(() => {
      alert("Logged Out");
      setCookie("user", null, { path: "/" }); // Remove the user cookie
      navigate("/");
    });
  };

  return (
    <div style={{ fontFamily: "Montserrat, sans-serrif" }}>
      <Navbar bg="light" variant="" expand="md" className="px-4">
        <Navbar.Brand as={Link} to="/">
          <img
            alt="logo"
            src="/images/logo.svg"
            width="30"
            height="30"
            className="d-inline-block align-top"
          />
          BookWorm
        </Navbar.Brand>
        <Navbar.Toggle aria-controls="navbar-nav" />
        <Navbar.Collapse id="navbar-nav" className="justify-content-center">
          <Nav>
            <Nav.Link as={Link} to="/">
              <FaHome /> Home
            </Nav.Link>
            <Nav.Link as={Link} to="/products">
              <FaProductHunt /> Products
            </Nav.Link>
            <Nav.Link as={Link} to="/library"><FaBook /> Library</Nav.Link>
            {cookies.user ? (
              <Nav.Link as={Link} to="/myshelf">
                <FaLayerGroup /> My Shelf
              </Nav.Link>
            ) : (
              <></>
            )}

            {/* <Nav.Link as={Link} to="/mylibrary"><FaBookReader /> My Library</Nav.Link> */}
            <NavDropdown
              title="More Options"
              id="collapsible-nav-dropdown"
              show={open}
              onMouseEnter={handleOpen}
              onMouseLeave={handleClose}
            >
              {cookies.user ? (
                <>
                  <Nav.Link as={Link} to="/myaccount" onClick={handleClose}>
                    <FaUserCircle /> My Account
                  </Nav.Link>
                  <NavDropdown.Divider />
                </>
              ) : (
                <></>
              )}

              <Nav.Link as={Link} to="/about" onClick={handleClose}>
                <FaInfoCircle /> About Us
              </Nav.Link>
              <Nav.Link as={Link} to="/contact" onClick={handleClose}>
                <FaPhone /> Contact Us
              </Nav.Link>
              <Nav.Link as={Link} to="/feedback" onClick={handleClose}>
                <FaComments /> Feedback
              </Nav.Link>
            </NavDropdown>
          </Nav>
        </Navbar.Collapse>
        {cookies.user ? (
          <Navbar.Text style={{ marginRight: "20px" }}>
            Welcome, User!
          </Navbar.Text>
        ) : (
          <Navbar.Text style={{ marginRight: "20px" }}>
            Welcome, Guest!
          </Navbar.Text>
        )}
        <Nav.Link
          as={Link}
          style={{ padding: "10px", marginRight: "20px" }}
          to="/cart"
        >
          <FaCartPlus /> Cart
        </Nav.Link>
        {!cookies.user ? (
          <Nav.Link as={Link} to="/login">
            <Button className="login-button-navbar">
              <FaSignInAlt /> Login/Register
            </Button>
          </Nav.Link>
        ) : (
          <Button className="logout-button" onClick={handlelogout}>
            <FaSignInAlt /> Logout
          </Button>
        )}
      </Navbar>
    </div>
  );
}
