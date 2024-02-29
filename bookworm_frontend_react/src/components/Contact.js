import React, { useState } from 'react';
import { Container, Row, Col, Form, Button } from 'react-bootstrap';
import axios from 'axios';
import config from '../config.json';

const Contact = () => {
    const [formData, setFormData] = useState({ name: '', email: '', subject: '', message: '' });

    const handleChange = (e) => {
        setFormData({ ...formData, [e.target.name]: e.target.value });
    };

    const handleSubmit = async (e) => {
        e.preventDefault();
        try {
            const emailData = {
                Name: formData.name,
                Email: 'infinityrisky999@gmail.com',
                Subject: formData.subject,
                Message: `Their email address is ${formData.email}. \n\nMessage - ${formData.message}`
            };
            await axios.post(`http://localhost:${config.port}/elasticemail/api/contact`, emailData);
            alert('Email sent successfully');
        } catch (err) {
            alert('Error sending email');
        }
    };

    return (
        <Container className="mt-5">
            <Row>
                <Col md={{ span: 6, offset: 3 }}>
                    <h2 className="text-center mb-4">Contact Us</h2>
                    <Form onSubmit={handleSubmit}>
                        <Form.Group controlId="formBasicName">
                            <Form.Label>Name</Form.Label>
                            <Form.Control type="text" placeholder="Enter your name" name="name" value={formData.name} onChange={handleChange} />
                        </Form.Group>

                        <Form.Group controlId="formBasicEmail">
                            <Form.Label>Email address</Form.Label>
                            <Form.Control type="email" placeholder="Enter email" name="email" value={formData.email} onChange={handleChange} />
                        </Form.Group>

                        <Form.Group controlId="formBasicSubject">
                            <Form.Label>Subject</Form.Label>
                            <Form.Control type="text" placeholder="Subject" name="subject" value={formData.subject} onChange={handleChange} />
                        </Form.Group>

                        <Form.Group controlId="formBasicMessage">
                            <Form.Label>Message</Form.Label>
                            <Form.Control as="textarea" rows={3} placeholder="Your message" name="message" value={formData.message} onChange={handleChange} />
                        </Form.Group>

                        <Button variant="primary" type="submit">
                            Submit
                        </Button>
                    </Form>
                </Col>
            </Row>
        </Container>
    );
};

export default Contact;