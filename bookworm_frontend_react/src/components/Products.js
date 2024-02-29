import { useEffect, useState } from "react";
import { Button, ButtonGroup, Container, Tab, Tabs } from "react-bootstrap";
import MyCard from "./MyCard";
import config from '../config.json';

export default function ProductsByLanguages() {
  const [productType, setProductType] = useState([]);
  const [languages, setLanguages] = useState([]);
  const [language, setLanguage] = useState(null);
  const [genres, setGenres] = useState([]);
  const [genre, setGenre] = useState(null);

  useEffect(() => {
    fetch(`http://localhost:${config.port}/api/productType/get`)
      .then((res) => res.json())
      .then((res) => setProductType(res));
  }, [])

  const handleSelect = (key) => {
    handleAllGenresClick();
    fetch(`http://localhost:${config.port}/api/language/getByTypeId/${key}`)
      .then((res) => res.json())
      .then((res) => setLanguages(res));
  }

  const handleClick = (languageId) => {
    setLanguage(languageId);
    fetch(`http://localhost:${config.port}/api/genre/getByLanguageId/${languageId}`)
      .then((res) => res.json())
      .then((res) => setGenres(res));
  }

  const handleGenreClick = (genreId) => {
    setGenre(genreId);
  }

  const handleAllGenresClick = () => {
  setGenre(null);
  setGenres([]);  // Set genres to an empty array
}

  return (
    <Tabs
      defaultActiveKey="1"
      id="justify-tab-example"
      className="mb-3"
      justify
      onSelect={handleSelect}
    >
      {productType.map((val) => (
        <Tab key={val.typeId} eventKey={val.typeId} title={val.typeDesc}>
          <Container className="justify-content-center">
            <ButtonGroup aria-label="Basic example">
              <Button variant="success" onClick={() => { setLanguage(null); handleAllGenresClick(); }}>All Languages</Button>
              {languages.map(lang => (
                <Button variant="secondary" onClick={() => handleClick(lang.languageId)}>{lang.languageDesc}</Button>
              ))}
            </ButtonGroup>
            <br/>
            <ButtonGroup aria-label="Basic example" className="pt-2">
              <Button variant="info" onClick={handleAllGenresClick}>All Genres</Button>
              {genres ? genres.map(gen => (
                <Button variant="dark" onClick={() => handleGenreClick(gen.genreId)}>{gen.genreDesc}</Button>
              )):(<></>)
            }
            </ButtonGroup>
            <MyCard typeId={val.typeId} selectedLanguage={language} selectedGenre={genre}></MyCard>
          </Container>
        </Tab>
      ))}
    </Tabs>
  );
}
