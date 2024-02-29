import 'bootstrap/dist/css/bootstrap.min.css';

import React from 'react';
import ReactDOM from 'react-dom/client';
import { BrowserRouter, Route, Routes } from 'react-router-dom';
import reportWebVitals from './reportWebVitals';

import './index.css';
import App from './App';
import Home from './components/Home';
import Contact from './components/Contact';
import Products from './components/Products';
import AboutUs from './components/AboutUs';
import NoPage from './components/NoPage';
import Login from './components/Login';
import Signup from './components/Signup';
import Cart from './components/Cart';
import ThankYou from './components/ThankYou';
import Myshelf from './components/Myshelf';
import User from './components/User';
import MyAccount from './components/MyAccount';
import Library from './components/Library';
import Packages from './components/Packages';

const root = ReactDOM.createRoot(document.getElementById('root'));
root.render(
  <BrowserRouter>
    <Routes>
      <Route path="/" element={<App />}>
        <Route path="/" element={<Home />} />
        <Route path="/home" element={<Home />} />
        <Route path="/contact" element={<Contact />} />
        <Route path="/about" element={<AboutUs />} />
        <Route path="/products" element={<Products />} />
        <Route path="/login" element={<Login />} />
        <Route path="/signup" element={<User />} />
        <Route path="/cart" element={<Cart />} />
        <Route path='/myshelf' element={<Myshelf />} />
        <Route path='/library' element={<Library />} />
        <Route path='/packages/:libraryId' element={<Packages />} />
        <Route path="/thankyou" element={<ThankYou />} />
        <Route path="/myaccount" element={<MyAccount />} />
        <Route path="*" element={<NoPage />} />
      </Route>
    </Routes>
  </BrowserRouter>
);

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();
