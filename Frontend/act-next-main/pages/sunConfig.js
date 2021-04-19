import React, { useEffect, useState } from "react";
import Head from "next/head";
import axios from "axios";
import useInput from "../components/hooks/useInput";
import { useRouter } from "next/router";

import Header from "../components/header/header.js";
import SideNav from "../components/sideNav/sideNav";
import BreadCrumb from "../components/breadCrumb/breadCrumb";

import Checked from "../public/images/checked.svg";
import NotChecked from "../public/images/notChecked.svg";
import Loader from "../public/images/loader.gif";
import Link from "next/link";

import { apiPath } from "../components/apiPath/apiPath";

const sunConfig = () => {
  useEffect(() => {
    axios.get(`${apiPath}Sun/GetConnectionString`).then((res) => {
      setConnectionString(res.data);
    });
  }, []);

  const router = useRouter();

  const {
    value: connectionString,
    resetValue: resetConnectionString,
    setValue: setConnectionString,
    bind: bindConnectionString,
  } = useInput("");

  const [loading, setLoading] = useState(false);

  const handleConfig = (e) => {
    e.preventDefault();
    axios
      .post(
        `${apiPath}Sun/UpdateConnectionString?ConnectionString=${connectionString}`
      )
      .then((res) => console.log(res))
      .catch((error) => {
        console.error("There was an error!", error.response.data);
      });

    router.push({
      pathname: `/sunDetailConfig`,
    });
  };

  const handleLoadDefaults = (e) => {
    e.preventDefault();
    setLoading(true);
    axios
      .post(`${apiPath}Sun/LoadDefaults`)
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
        console.error("There was an error!", error);
      });
  };

  return (
    <div>
      <Head>
        <title>Sun Config</title>
      </Head>
      <Header />
      <SideNav />
      {loading && (
        <div className="loader">
          <img src={Loader} alt="loader" />
        </div>
      )}
      <main className="main-sun-config">
        <div className="container">
          <div className="main_sun_head">
            <div className="head">
              <h5>Sun Configraution</h5>
              <span type="button" onClick={handleLoadDefaults}>
                Load Defaults
              </span>
            </div>
            <BreadCrumb path="sunConfig" page="Sun Configraution" />
          </div>

          <div className={`main_sun_body ${loading && "loading"}`}>
            <div className="container">
              <div className="links">
                <div className="active">
                  <Link href="/sunConfig">
                    <a>
                      <img src={Checked} alt="Checked" />

                      <span>Configration</span>
                    </a>
                  </Link>
                </div>
                <div>
                  <Link href="/sunDetailConfig">
                    <a>
                      <img src={NotChecked} alt="NotChecked" />
                      <span>Sun Detail Configration</span>
                    </a>
                  </Link>
                </div>
                <div>
                  <Link href="/sunHDRConfig">
                    <a>
                      <img src={NotChecked} alt="NotChecked" />
                      <span>Sun HDR Configration</span>
                    </a>
                  </Link>
                </div>
              </div>
              <form onSubmit={handleConfig}>
                <label>Connection</label>
                <input
                  type="text"
                  placeholder="Connection"
                  required
                  {...bindConnectionString}
                />
                <button type="submit">Config</button>
              </form>
            </div>
          </div>
        </div>
      </main>
    </div>
  );
};
export default sunConfig;
