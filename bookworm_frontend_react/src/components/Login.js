import React, { useState } from "react";
import { Link, useNavigate } from "react-router-dom";
import { useCookies } from "react-cookie";
import "../css/Login.css";
import config from '../config.json';

function Login() {
  const [user, setUser] = useState({});
  const [cookies, setCookie] = useCookies(["user"]);
  const navigate = useNavigate();

  const handleInputChange = (e) => {
    const { name, value } = e.target;
    setUser((values) => ({
      ...values,
      [name]: value,
    }));
  };

  const handleSubmit = (e) => {
    e.preventDefault();

    let data = JSON.stringify(user);

    fetch(`http://localhost:${config.port}/api/customer/login`, {
      method: "POST",
      headers: { "Content-type": "application/json" },
      body: data,
    })
      .then((response) => {
        if (response.ok) {
          // Replace with actual success check
          return response.text();
        } else {
          alert("Login failed");
          throw new Error("Login failed");
        }
      })
      .then((userId) => {
        setCookie("user", userId, { path: "/" });
        alert("Done");
        navigate("/");
      })
      .catch((error) => console.error("Error:", error));
  };

  return (
    <div className="login template d-flex justify-content-center align-items-center vh-100">
      <div className="form_container p-5 rounded bg-white shadow">
        <form onSubmit={handleSubmit}>
          <h2 className="text-center mb-4">Log In</h2>
          <div className="mb-3">
            <label htmlFor="customerEmail" className="form-label">
              Email
            </label>
            <input
              type="email"
              name="customerEmail"
              placeholder="Enter Email"
              className="form-control"
              onChange={handleInputChange}
            />
          </div>
          <div className="mb-3">
            <label htmlFor="password" className="form-label">
              Password
            </label>
            <input
              type="password"
              name="password"
              placeholder="Enter Password"
              className="form-control"
              onChange={handleInputChange}
            />
            <p className="text-end mt-0">Forgot Password?</p>
          </div>
          <div className="mb-3 form-check">
            <input type="checkbox" className="form-check-input" id="check" />
            <label htmlFor="check" className="form-check-label ms-2">
              Remember me
            </label>
          </div>

          <div className="d-grid">
            <button
              type="submit"
              className="login-button"
              // style={{ background: "black", color: "white", border: "none" }}
            >
              Sign in
            </button>
            <p className="mt-4" style={{ fontSize: "16px" }}>
              Don't have an account?{" "}
              <u>
                <Link to="/signup">Sign up</Link>
              </u>
            </p>
          </div>
        </form>
      </div>
    </div>
  );
}

export default Login;
