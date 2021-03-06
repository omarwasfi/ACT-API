import React, { useState } from "react";
import Head from "next/head";
import axios from "axios";
import { apiPath } from "../components/apiPath/apiPath";

import Group from "../public/images/group.png";
import SubLogo from "../public/images/subLogo.svg";
import num from "../public/images/98.png";
import Loader from "../public/images/loader.gif";

import Link from "next/link";

export default function Home() {
  const [loading, setLoading] = useState(false);
  const handleDefaults = (e) => {
    e.preventDefault();
    setLoading(true);
    axios
      .post(`${apiPath}Sun/LoadDefaults`)
      .then((res) => console.log(res.data))
      .catch((error) => {
        console.error("There was an error!", error.response.data);
      });

    axios
      .post(`${apiPath}Hrms/LoadDefaults`)
      .then((res) => console.log(res.status))
      .catch((error) => {
        console.error("There was an error!", error);
      });

    axios
      .post(`${apiPath}Opera/LoadDefaults`)
      .then((res) => console.log(res.data))
      .catch((error) => {
        console.error("There was an error!", error.response.data);
      });

    axios
      .post(`${apiPath}Mapping/HrmsToSun/ReportToDetail/LoadDefaults`)
      .then((res) => console.log(res.data))
      .catch((error) => {
        console.error("There was an error!", error.response.data);
      });

    axios
      .post(`${apiPath}Mapping/HrmsToSun/ReportToHdr/LoadDefaults`)
      .then((res) => console.log(res.data))
      .catch((error) => {
        console.error("There was an error!", error.response.data);
      });
    axios
      .post(`${apiPath}Mapping/OperaToSun/ReportToDetail/LoadDefaults`)
      .then((res) => console.log(res.data))
      .catch((error) => {
        console.error("There was an error!", error.response.data);
      });
    axios
      .post(`${apiPath}Mapping/OperaToSun/ReportToHDR/LoadDefaults`)
      .then((res) => {
        if (res.status === 200) {
          console.log("load defaults is done");
          axios(`${apiPath}Shutdown/blow-me-up`)
            .then((res) => {
              if (res.status === 200) {
                console.log("shut down is done");
                setLoading(false);
              }
            })
            .catch((error) => {
              console.error("There was an error!", error);
            });
        }
      })
      .catch((error) => {
        console.error("There was an error!", error.response.data);
      });
  };

  return (
    <div>
      <Head>
        <title>Home</title>
        <link rel="icon" href="/favicon.ico" />
      </Head>
      {loading && (
        <div className="loader">
          <img src={Loader} alt="loader" />
        </div>
      )}
      <main className={`main ${loading && "loading"}`}>
        <div
          id="black-corner"
          className="text-center d-flex align-items-center"
        >
          <img
            className="d-block m-auto"
            width="182"
            height="80"
            src={num}
            alt=""
          />
        </div>
        <div id="orange-corner"></div>
        <div id="white-circle"></div>
        <div id="FC2839-largeCircle"></div>
        <div id="FC2839-smallCircle"></div>
        <div
          id="all-content"
          style={{ position: "absolute", left: "15%" }}
          className={`row m-auto ${loading && "loading"}`}
        >
          <div className="col-12 col-lg-6 m-auto order-2 order-lg-1">
            <h2 className="mb-3 ml-auto mr-auto">create like never before</h2>
            <p className="ml-auto mr-auto mb-3">
              welcome to our application, let's start connecting
            </p>
            <div className="m-auto">
              <Link href="/sunConfig">
                <a id="button">get started</a>
              </Link>
              <a id="link">
                <button
                  style={{
                    background: "none",
                    border: "none",
                    fontWeight: "bold",
                    outline: "none",
                  }}
                  onClick={handleDefaults}
                >
                  Load all Defaults
                </button>
              </a>
            </div>
          </div>
          <div
            id="img-div"
            className="col-12 col-lg-6 m-auto order-1 order-lg-2"
          ></div>
        </div>
      </main>
    </div>
  );
}
