import React from 'react';
import { Link } from 'react-router-dom';
import { Navbar, Nav } from 'react-bootstrap';
import { FaHome, FaProductHunt, FaInfoCircle, FaEnvelope, FaUser } from 'react-icons/fa';
import 'bootstrap/dist/css/bootstrap.min.css';

const Header = () => {
  return (
    <Navbar bg="dark" variant="dark" expand="lg">
      <Navbar.Brand as={Link} to="/">
        <img
          src="/logo.png"
          width="50"
          height="50"
          className="d-inline-block align-top"
          alt="Bookworm logo"
        />
        Bookworm
      </Navbar.Brand>
      <Navbar.Toggle aria-controls="basic-navbar-nav" />
      <Navbar.Collapse id="basic-navbar-nav" className="justify-content-center">
        <Nav>
          <Nav.Link as={Link} to="/"><FaHome /> Home</Nav.Link>
          <Nav.Link as={Link} to="/products"><FaProductHunt /> Products</Nav.Link>
          <Nav.Link as={Link} to="/about"><FaInfoCircle /> About Us</Nav.Link>
          <Nav.Link as={Link} to="/contact"><FaEnvelope /> Contact Us</Nav.Link>
        </Nav>
      </Navbar.Collapse>
      <Navbar.Brand style={{ padding: '10px' }} as={Link} to="/">Login/Register</Navbar.Brand>
    </Navbar>
  );
};

export default Header;