import React from 'react'

export default function ExampleCarouselImage({src,text}) {
  return (
    <img
      className="d-block w-100"
      src={src}
      alt={text}
      style={{ maxHeight: '100vh', maxWidth: '100%', objectFit: 'cover' }}
    />
  );

}
