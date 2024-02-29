import React, { useEffect, useState } from "react";
import { useCookies } from "react-cookie";
import { Container, Row, Col, ListGroup, Card } from "react-bootstrap";
import "../css/MyShelf.css";
import { useNavigate } from "react-router-dom";
import config from '../config.json';
import { propTypes } from "react-bootstrap/esm/Image";

export default function MyShelf() {
  const [cookies] = useCookies(["user"]);
  const [products, setProducts] = useState([]);
  const [hoveredBook, setHoveredBook] = useState(null);
  const navigate = useNavigate();

  //   console.log(hoveredBook);

  useEffect(() => {
    if (cookies.user) {
      fetch(`http://localhost:${config.port}/api/myshelf/getbycustomer/${cookies.user}`)
        .then((res) => res.json())
        .then((data) => {
          setProducts(data);
        })
        .catch((error) => console.log(error));
    } else {
      navigate("/login");
    }
  }, [cookies.user]);

  const handleCardClick = (productId, productEngName) => {
    fetch(`http://localhost:${config.port}/api/producturl/${productId}`)
      .then((res) => res.text())
      .then((data) => {
        window.open(
          process.env.PUBLIC_URL + "/book_pdfs/" + productEngName + ".pdf",
          "_blank"
        );
      })
      .catch((error) => console.log(error));
  };

  return (
    <Container fluid="sm">
      <Row>
        <Col md={{ span: 12, offset: 1 }} lg={{ span: 8, offset: 2 }}>
          <h4 className="d-flex justify-content-between align-items-center mb-3 mt-3">
            <span className="text-primary">Your Shelf</span>
          </h4>
          <Row className="g-4">
            {products.map((product) => (
              <Col key={product.productId} md={4}>
                <ListGroup.Item className="d-flex justify-content-between lh-sm">
                  <Card
                    style={{ width: "18rem", cursor: "pointer" }}
                    onClick={() =>
                      handleCardClick(product.productId, product.productEngName)
                    }
                    onMouseEnter={() => setHoveredBook(product.productEngName)}
                    onMouseLeave={() => setHoveredBook(null)}
                  >
                    <Card.Img
                      style={{ width: 230, height: 300, objectFit: "cover" }}
                      variant="top"
                      src={"/book_covers/" + product.productEngName + ".jpg"}
                    />
                    {hoveredBook == product.productEngName && (
                      <div
                        className="book-title-overlay"
                        style={{ padding: "10px" }}
                      >
                        {product.productEngName}
                        {/* {console.log("Hello")} */}
                      </div>
                    )}
                  </Card>
                </ListGroup.Item>
              </Col>
            ))}
          </Row>
        </Col>
      </Row>
    </Container>
  );
}
