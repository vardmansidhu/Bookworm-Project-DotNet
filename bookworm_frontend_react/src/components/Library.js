import React, { useEffect, useState } from "react";
import config from "../config.json";
import { Card, Col, Row } from "react-bootstrap";
import { useNavigate } from "react-router-dom";

export default function Library() {
  const [packages, setPackages] = useState([]);
  const navigate = useNavigate();

  useEffect(() => {
    fetch(`http://localhost:${config.port}/api/Library/get`)
      .then((res) => res.json())
      .then((data) => setPackages(data));
  }, []);
  return (
    <div>
      {packages.map((pack) => (
        <div key={pack.libraryPackageId}>
          <Row xs={1} md={4} className="g-4 m-5 text-center">
            <Col>
              <Card
                onClick={() => navigate(`/packages/${pack.libraryPackageId}`)}
              >
                {/* <Card.Img variant="top" src="holder.js/100px160" /> */}
                <Card.Body>
                  <Card.Title>{pack.name}</Card.Title>
                  <Card.Text>Price: {pack.price}</Card.Text>
                  <Card.Text>No. Of Days: {pack.noOfDays}</Card.Text>
                  <Card.Text>Maximum Books: {pack.maxBooks}</Card.Text>
                </Card.Body>
              </Card>
            </Col>
          </Row>
        </div>
      ))}
    </div>
  );
}
