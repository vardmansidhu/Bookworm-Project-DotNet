import React, { useState } from 'react';
import { Link } from 'react-router-dom';
import config from '../config.json';

function Signup() {
  const [customer, setCustomer] = useState({});
  const [exists, setExists] = useState(false);

  const handleInputChange = (e) => {
    const { name, value } = e.target;
    setCustomer(customer => ({
      ...customer,
      [name]: value,
    }));
  };

  const handleFormSubmit = (e) => {
    e.preventDefault();
    
      let data = JSON.stringify(customer);
      alert(data);

      fetch(`http://localhost:${config.port}/api/customer/exists?email=` + customer.customerEmail).then(response => response.json()).then(data => setExists(data));

      if (exists) {
        alert("User already exists");
      }else{
      fetch(`http://localhost:${config.port}/api/customer/add`, {
        method: "POST",
        headers: { "Content-type": "application/json" },
        body: data 
      })
    }
  };

  return (
    <div className='signup template d-flex justify-content-center align-items-center vh-100 bg-primary '>
      <div className='form_container p-5 rounded bg-white'>
        <form onSubmit={handleFormSubmit}>
          <h2 className='text-center'>Sign up</h2>

          <div className='mb-2'>
            <label htmlFor="fullName">Full Name</label>
            <input
              type="text"
              name="customerName"
              placeholder='Enter Full Name'
              className='form-control'
              value={customer.customerName}
              onChange={handleInputChange}
            />
            {/* {errors.customerName && <p className='text-danger'>{errors.customerName}</p>} */}
          </div>

          <div className='mb-2'>
            <label htmlFor="email">Email</label>
            <input
              type="email"
              name="customerEmail"
              placeholder='Enter E-mail Address'
              className='form-control'
              value={customer.customerEmail}
              onChange={handleInputChange}
            />
            {/* {errors.customerEmail && <p className='text-danger'>{errors.customerEmail}</p>} */}
          </div>

          <div className='mb-2'>
            <label htmlFor="mobile No">Mobile Number</label>
            <input
              type="tel"
              name="contactNo"
              placeholder='Enter Mobile No'
              className='form-control'
              value={customer.contactNo}
              onChange={handleInputChange}
            />
            {/* {errors.contactNo && <p className='text-danger'>{errors.contactNo}</p>} */}
          </div>

          <div className='mb-2'>
            <label htmlFor="Date-Of-Birth">Date of Birth</label>
            <input
              type="date"
              name="dob"
              placeholder='Enter DOB '
              className='form-control'
              value={customer.dob}
              onChange={handleInputChange}
            />
            {/* {errors.dob && <p className='text-danger'>{errors.dob}</p>} */}
          </div>

          <div className='mb-2'>
            <label htmlFor="password">Password</label>
            <input
              type="password"
              name="password"
              placeholder='Enter Password '
              className='form-control'
              value={customer.password}
              onChange={handleInputChange}
            />
            {/* {errors.password && <p className='text-danger'>{errors.password}</p>} */}
          </div>

          <div className='mb-2'>
            <label htmlFor="confirmPassword">Confirm Password</label>
            <input
              type="password"
              name="confirmPassword"
              placeholder='Enter Password '
              className='form-control'
              value={customer.confirmPassword}
            //onChange={handlePasswordChange}
            />
            {/* {errors.confirmPassword && <p className='text-danger'>{errors.confirmPassword}</p>} */}
          </div>

          <div className='d-grid'>
            <button type="submit" className='btn btn-primary'>Sign Up</button>
          </div>

          <p className='text-end mt-2'>
            Already Registered <Link to="/login" className='ms-2'>Sign in</Link>
          </p>
        </form>
      </div>
    </div>
  );
}

export default Signup;