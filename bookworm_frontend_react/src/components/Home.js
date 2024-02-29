import React, { useEffect, useState } from "react";
import MyCarousel from "./MyCarousel";
import { useCookies } from "react-cookie";

export default function Home() {
  const [cookies, setCookie] = useCookies(["user"]);

  return (
    <div>
      <MyCarousel />
      <h1
        style={{
          fontFamily: "Montserrat,sans-serif",
          display: "flex",
          justifyContent: "center",
          padding: "30px",
        }}
      >
        Trending
      </h1>
      {/* <h1>Upcoming</h1> */}
    </div>
  );
}
