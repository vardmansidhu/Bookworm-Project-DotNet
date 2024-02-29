import React from 'react';
import { Form, Button, Container, Row, Col } from 'react-bootstrap';
import { useForm, Controller } from 'react-hook-form';
import { useNavigate } from 'react-router-dom';
import config from '../config.json';

const MyForm = () => {
  const { handleSubmit, control, formState: { errors }, watch } = useForm();
  const password = watch('password');
  const navigate = useNavigate();

  const onSubmit = (formdata) => {  
      fetch(`http://localhost:${config.port}/api/customer/exists?email=` + formdata.customerEmail)
        .then(response => response.json())
        .then(data => {
          if (data) {
            alert("User already exists");
          }else{
            fetch(`http://localhost:${config.port}/api/customer/add`, {
            method: 'POST',
            headers: {
              'Content-Type': 'application/json'
            },
            body: JSON.stringify(formdata)
          })
            .then(res => alert("Registration Successful"), err => alert("Registration Not Successful"))
            .then(()=>navigate('/login'))
        }
        });
  };

  return (
    <Container>
      <h2 className="mt-4">Customer Registration Form</h2>
      <Form className="custom-form" onSubmit={handleSubmit(onSubmit)}>
        <Row className="mb-3">
          <Form.Group as={Col} controlId="customerEmail">
            <Form.Label>Email:</Form.Label>
            <Controller
              render={({ field }) => (
                <Form.Control
                  type="email"
                  {...field}
                  isInvalid={errors.customerEmail}
                />
              )}
              name="customerEmail"
              control={control}
              rules={{ required: 'Please enter your email' }}
            />
            <Form.Control.Feedback type="invalid">
              {errors.customerEmail && errors.customerEmail.message}
            </Form.Control.Feedback>
          </Form.Group>
          <Form.Group as={Col} controlId="password">
            <Form.Label>Password:</Form.Label>
            <Controller
              render={({ field }) => (
                <Form.Control
                  type="password"
                  {...field}
                  isInvalid={errors.password}
                />
              )}
              name="password"
              control={control}
              rules={{
                required: 'Password is required',
                minLength: {
                  value: 8,
                  message: 'Password must be at least 8 characters'
                }
              }}
            />
            <Form.Control.Feedback type="invalid">
              {errors.password && errors.password.message}
            </Form.Control.Feedback>
          </Form.Group>
          <Form.Group as={Col} controlId="confirmPassword">
            <Form.Label>Confirm Password:</Form.Label>
            <Controller
              render={({ field }) => (
                <Form.Control
                  type="password"
                  {...field}
                  isInvalid={errors.confirmPassword}
                />
              )}
              name="confirmPassword"
              control={control}
              rules={{
                required: 'Please confirm your password',
                validate: (value) =>
                  value === password || 'Passwords do not match',
              }}
            />
            <Form.Control.Feedback type="invalid">
              {errors.confirmPassword && errors.confirmPassword.message}
            </Form.Control.Feedback>
          </Form.Group>
        </Row>

        <Row className="mb-3">
          <Form.Group as={Col} controlId="customerName">
            <Form.Label>Name:</Form.Label>
            <Controller
              render={({ field }) => (
                <Form.Control
                  type="text"
                  {...field}
                  isInvalid={errors.customerName}
                />
              )}
              name="customerName"
              control={control}
              rules={{ required: 'Please enter your name' }}
            />
            <Form.Control.Feedback type="invalid">
              {errors.customerName && errors.customerName.message}
            </Form.Control.Feedback>
          </Form.Group>
          <Form.Group as={Col} controlId="contactNo">
            <Form.Label>Contact Number:</Form.Label>
            <Controller
              render={({ field }) => (
                <Form.Control
                  type="text"
                  {...field}
                  isInvalid={errors.contactNo}
                />
              )}
              name="contactNo"
              control={control}
              rules={{
                required: 'Contact number is required',
                pattern: {
                  value: /^\d{10}$/,
                  message: 'Contact number must be 10 digits and numeric'
                }
              }}
            />
            <Form.Control.Feedback type="invalid">
              {errors.contactNo && errors.contactNo.message}
            </Form.Control.Feedback>
          </Form.Group>


          <Form.Group as={Col} controlId="dob">
            <Form.Label>Date of Birth:</Form.Label>
            <Controller
              render={({ field }) => (
                <Form.Control
                  type="date"
                  {...field}
                  isInvalid={errors.dob}
                />
              )}
              name="dob"
              control={control}
              rules={{
                required: 'Date of birth is required',
                validate: (value) => {
                  let today = new Date();
                  let birthDate = new Date(value);
                  let age = today.getFullYear() - birthDate.getFullYear();
                  let m = today.getMonth() - birthDate.getMonth();
                  if (m < 0 || (m === 0 && today.getDate() < birthDate.getDate())) {
                    age--;
                  }
                  return age >= 13 || 'You must be at least 13 years old';
                }
              }}
            />
            <Form.Control.Feedback type="invalid">
              {errors.dob && errors.dob.message}
            </Form.Control.Feedback>
          </Form.Group>
        </Row>




        <Row className="mb-3">
          <Form.Group as={Col} controlId="language1">
            <Form.Label>Preferred Language 1:</Form.Label>
            <Controller
              render={({ field }) => (
                <Form.Control
                  as="select"
                  {...field}
                  isInvalid={errors.language1}
                >
                  <option value="">Select Language</option>
                  <option value="1">English</option>
                  <option value="2">Marathi</option>
                  <option value="3">Hindi</option>
                </Form.Control>
              )}
              name="language1"
              control={control}
            />
            <Form.Control.Feedback type="invalid">
              {errors.language1 && errors.language1.message}
            </Form.Control.Feedback>
          </Form.Group>
          <Form.Group as={Col} controlId="language2">
            <Form.Label>Preferred Language 2:</Form.Label>
            <Controller
              render={({ field }) => (
                <Form.Control
                  as="select"
                  {...field}
                  isInvalid={errors.language2}
                >
                  <option value="">Select Language</option>
                  <option value="1">English</option>
                  <option value="2">Marathi</option>
                  <option value="3">Hindi</option>
                </Form.Control>
              )}
              name="language2"
              control={control}
            />
            <Form.Control.Feedback type="invalid">
              {errors.language2 && errors.language2.message}
            </Form.Control.Feedback>
          </Form.Group>
          <Form.Group as={Col} controlId="language3">
            <Form.Label>Preferred Language 3:</Form.Label>
            <Controller
              render={({ field }) => (
                <Form.Control
                  as="select"
                  {...field}
                  isInvalid={errors.language3}
                >
                  <option value="">Select Language</option>
                  <option value="1">English</option>
                  <option value="2">Marathi</option>
                  <option value="3">Hindi</option>
                </Form.Control>
              )}
              name="language3"
              control={control}
            />
            <Form.Control.Feedback type="invalid">
              {errors.language3 && errors.language3.message}
            </Form.Control.Feedback>
          </Form.Group>
        </Row>

        <Row className="mb-3">
          <Form.Group as={Col} controlId="genre1">
            <Form.Label>Prefered Genre 1:</Form.Label>
            <Controller
              render={({ field }) => (
                <Form.Control
                  as="select"
                  {...field}
                  isInvalid={errors.genre1}
                >
                  <option value="">Select Genre</option>
                  <option value="1">Science Fiction</option>
                  <option value="2">Fantasy</option>
                  <option value="3">Mystery</option>
                  <option value="4">Romance</option>
                  <option value="5">Thriller</option>
                  <option value="6">Horror</option>
                  <option value="7">Adventure</option>
                  <option value="8">Action</option>
                  <option value="9">Comedy</option>
                </Form.Control>
              )}
              name="genre1"
              control={control}
            />
            <Form.Control.Feedback type="invalid">
              {errors.genre1 && errors.genre1.message}
            </Form.Control.Feedback>
          </Form.Group>

          <Form.Group as={Col} controlId="genre2">
            <Form.Label>Prefered Genre 2:</Form.Label>
            <Controller
              render={({ field }) => (
                <Form.Control
                  as="select"
                  {...field}
                  isInvalid={errors.genre2}
                >
                  <option value="">Select Genre</option>
                  <option value="1">Science Fiction</option>
                  <option value="2">Fantasy</option>
                  <option value="3">Mystery</option>
                  <option value="4">Romance</option>
                  <option value="5">Thriller</option>
                  <option value="6">Horror</option>
                  <option value="7">Adventure</option>
                  <option value="8">Action</option>
                  <option value="9">Comedy</option>
                </Form.Control>
              )}
              name="genre2"
              control={control}
            />
            <Form.Control.Feedback type="invalid">
              {errors.genre2 && errors.genre2.message}
            </Form.Control.Feedback>
          </Form.Group>

          <Form.Group as={Col} controlId="genre3">
            <Form.Label>Prefered Genre 3:</Form.Label>
            <Controller
              render={({ field }) => (
                <Form.Control
                  as="select"
                  {...field}
                  isInvalid={errors.genre3}
                >
                  <option value="">Select Genre</option>
                  <option value="1">Science Fiction</option>
                  <option value="2">Fantasy</option>
                  <option value="3">Mystery</option>
                  <option value="4">Romance</option>
                  <option value="5">Thriller</option>
                  <option value="6">Horror</option>
                  <option value="7">Adventure</option>
                  <option value="8">Action</option>
                  <option value="9">Comedy</option>
                </Form.Control>
              )}
              name="genre3"
              control={control}
            />
            <Form.Control.Feedback type="invalid">
              {errors.genre3 && errors.genre3.message}
            </Form.Control.Feedback>
          </Form.Group>
        </Row>

        <Row className="mb-3">
          <Col className="text-center">
            <Button variant="primary" type="submit">
              Register
            </Button>
          </Col>
        </Row>

      </Form>
    </Container>
  );
};

export default MyForm;
