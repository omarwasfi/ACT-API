import React, { useEffect, useRef, useState } from "react";
import Head from "next/head";
import axios from "axios";
import useInput from "../components/hooks/useInput";
import { useRouter } from "next/router";

import Header from "../components/header/header.js";
import SideNav from "../components/sideNav/sideNav";
import BreadCrumb from "../components/breadCrumb/breadCrumb";

import Checked from "../public/images/checked.svg";
import NotChecked from "../public/images/notChecked.svg";
import Trash from "../public/images/trash.svg";
import Edit from "../public/images/edit.svg";
import Link from "next/link";

import { apiPath } from "../components/apiPath/apiPath";

const mappingOperaToSunHDR = () => {
  const {
    value: sunAttribute,
    resetValue: resetSunAttribute,
    setValue: setSunAttribute,
    bind: bindSunAttribute,
  } = useInput("");

  const {
    value: valueOfType,
    resetValue: resetValueOfType,
    setValue: setValueOfType,
    bind: bindValueOfType,
  } = useInput("");

  const [columns, setColumns] = useState([]);

  const types = ["DateTime", "Decimal", "Double", "Int", "String", "Short"];

  const [type, setType] = useState("");
  const [mapWithOperaName, setMapWithOperaName] = useState("");
  const [mapWithOperaNames, setMapWithOperaNames] = useState([]);
  const [conditionForType, setConditionForType] = useState("");

  useEffect(() => {
    axios
      .get(`${apiPath}Mapping/OperaToSun/ReportToHDR/GetOperaReportSunHdr`)
      .then((res) => {
        setColumns(res.data);
        console.log(res.data);
      });

    axios.get(`${apiPath}Opera/Report/GetColumns`).then((res) => {
      setMapWithOperaNames(res.data.map((name) => name.name));
    });
  }, []);

  const handleSubmit = (e) => {
    e.preventDefault();

    if (condition === "isConst") {
      setColumns([
        ...columns,
        {
          sunAttribute: sunAttribute,
          valueType: type,
          [conditionForType]: valueOfType,
          isConst: true,
          autoGenerated: false,
        },
      ]);
    } else if (condition === "isAuto") {
      setColumns([
        ...columns,
        {
          sunAttribute: sunAttribute,
          valueType: type,
          isConst: false,
          autoGenerated: true,
        },
      ]);
    } else if (condition === "mapWithOpera") {
      setColumns([
        ...columns,
        {
          sunAttribute: sunAttribute,
          valueType: type,
          mapWithOPERA: mapWithOperaName,
          isConst: false,
          autoGenerated: false,
        },
      ]);
    }
    setSunAttribute("");
    setType("");
    setValueOfType("");
  };

  const [nunberOrString, setNumberOrString] = useState(true);

  useEffect(() => {
    if (type === "DateTime") {
      setConditionForType("dateTimeValue");
    } else if (type === "Decimal") {
      setConditionForType("decimalValue");
      if (valueOfType) setValueOfType(parseInt(valueOfType));
    } else if (type === "Double") {
      setConditionForType("doubleValue");
      if (valueOfType) setValueOfType(parseInt(valueOfType));
    } else if (type === "Int") {
      setConditionForType("intValue");
      if (valueOfType) setValueOfType(parseInt(valueOfType));
    } else if (type === "Short") {
      setConditionForType("shortValue");
      if (valueOfType) setValueOfType(parseInt(valueOfType));
    } else if (type === "String") {
      setConditionForType("stringValue");
    }
    if (type === "DateTime" || type === "String") {
      setNumberOrString(false);
    } else if (
      type === "Decimal" ||
      type === "Double" ||
      type === "Int" ||
      type === "Short"
    ) {
      setNumberOrString(true);
    }
  }, [type, valueOfType]);

  const isFirstRender = useRef(true);

  useEffect(() => {
    if (!isFirstRender.current) {
      // do something after state has updated
      if (columns.length > 0) {
        const columnsConfig = {
          method: "POST",
          headers: { "Content-Type": "application/json" },
          data: [...columns],
        };
        axios(
          `${apiPath}/Mapping/OperaToSun/ReportToHDR/UpdateOperaReportSunHdr`,
          columnsConfig
        )
          .then((res) => console.log(res))
          .catch((error) => {
            console.error("There was an error!", error);
          });
      } else {
        alert("Error!");
      }
    }
  }, [columns]);

  useEffect(() => {
    isFirstRender.current = false; // toggle flag after first render/mounting
  }, []);

  const [isEdited, setIsEdited] = useState(false);

  const [idOfeditedColumn, setIdOfEditedColumn] = useState("");

  const handleEdit = (sunAttribute, valueType, i) => {
    setIsEdited(true);
    setSunAttribute(sunAttribute);
    setIdOfEditedColumn(sunAttribute);
  };

  const handleUpdate = () => {
    setColumns(
      columns.map((column) => {
        if (column.sunAttribute !== idOfeditedColumn) return column;
        else {
          if (condition === "isConst") {
            return {
              ...columns,
              sunAttribute: sunAttribute,
              valueType: type,
              [conditionForType]: valueOfType,
              isConst: true,
              autoGenerated: false,
            };
          } else if (condition === "isAuto") {
            return {
              ...columns,
              sunAttribute: sunAttribute,
              valueType: type,
              isConst: false,
              autoGenerated: true,
            };
          } else if (condition === "mapWithOpera") {
            return {
              ...columns,
              sunAttribute: sunAttribute,
              valueType: type,
              mapWithOPERA: mapWithOperaName,
              isConst: false,
              autoGenerated: false,
            };
          }
        }
      })
    );
    setIsEdited(false);
    setSunAttribute("");
    setType("");
    setValueOfType("");
  };

  const handleDelete = (sunAttribute) => {
    if (columns.length > 0) {
      const newColumns = columns.filter(
        (item) => item.sunAttribute !== sunAttribute
      );
      setColumns([...newColumns]);
    }
  };

  const [condition, setCondition] = useState("");

  const handleCondition = (e) => {
    setCondition(e.target.value);
  };

  const handleTypeChange = (e) => {
    setType(e.target.value);
  };

  const handleLoadDefaults = (e) => {
    e.preventDefault();
    axios
      .post(`${apiPath}Mapping/OperaToSun/ReportToHDR/LoadDefaults`)
      .then((res) => console.log(res.data))
      .catch((error) => {
        console.error("There was an error!", error.response.data);
      });
  };

  return (
    <div>
      <Head>
        <title>Mapping Opera To Sun HDR</title>
      </Head>

      <Header />
      <SideNav />

      <main className="main-sun-config">
        <div className="container">
          <div className="main_sun_head">
            <div className="head">
              <h5>Mapping Opera Configraution</h5>
              <span type="button" onClick={handleLoadDefaults}>
                Load Defaults
              </span>
            </div>
            <BreadCrumb
              path="mappingOperaToSunHDR"
              page="Mapping Opera Configraution"
            />
          </div>

          <div className="main_sun_body scrollable">
            <div className="container">
              <form
                onSubmit={isEdited ? handleUpdate : handleSubmit}
                className="multi-inputs more"
                style={{ marginTop: "30px" }}
              >
                <h5>Add new Column</h5>
                <div>
                  <div>
                    <label>Sun Attribute</label>
                    <input type="text" {...bindSunAttribute} required />
                  </div>
                  <div className="select-with-label">
                    <label>Choose a Type</label>
                    <select
                      name="columns"
                      id="columns"
                      onChange={(e) => handleTypeChange(e)}
                    >
                      {types.map((type, i) => (
                        <option key={i} value={type}>
                          {type}
                        </option>
                      ))}
                    </select>
                  </div>
                  <div className="radio-buttons">
                    <span>Choose</span>
                    <div>
                      <input
                        type="radio"
                        id="isConst"
                        name="condition"
                        onChange={(e) => handleCondition(e)}
                        value="isConst"
                      />
                      <label htmlFor="isConst">isConst</label>
                    </div>

                    <div>
                      <input
                        type="radio"
                        id="isAuto"
                        name="condition"
                        onChange={(e) => handleCondition(e)}
                        value="isAuto"
                      />
                      <label htmlFor="isAuto">isAuto</label>
                    </div>
                    <div>
                      <input
                        type="radio"
                        id="mapWithOpera"
                        name="condition"
                        onChange={(e) => handleCondition(e)}
                        value="mapWithOpera"
                      />
                      <label htmlFor="mapWithOpera">mapWithOpera</label>
                    </div>
                  </div>
                  <div>
                    {condition === "isConst" && (
                      <>
                        <label>Value</label>
                        <input
                          type={nunberOrString ? "number" : "text"}
                          {...bindValueOfType}
                          required
                        />
                      </>
                    )}
                    {condition === "isAuto" && null}
                    {condition === "mapWithOpera" && (
                      <select
                        name="mapWithOperaName"
                        id="mapWithOperaName"
                        onChange={(e) => setMapWithOperaName(e.target.value)}
                      >
                        {mapWithOperaNames.map((mapWithOperaName, i) => (
                          <option key={i} value={mapWithOperaName}>
                            {mapWithOperaName}
                          </option>
                        ))}
                      </select>
                    )}
                  </div>

                  <div>
                    {isEdited ? (
                      <button type="button" onClick={handleUpdate}>
                        Update Column
                      </button>
                    ) : (
                      <button type="button" onClick={handleSubmit}>
                        Submit
                      </button>
                    )}
                  </div>
                </div>
              </form>

              <div className="table">
                <table>
                  <tr>
                    <th>Sun Attribute</th>
                    <th>Value Type</th>
                    <th>Auto Generated</th>
                    <th>Is Const</th>
                    <th>Map With OPERA</th>
                    <th>Settings</th>
                  </tr>
                  {columns.map(
                    (
                      {
                        sunAttribute,
                        valueType,
                        id,
                        autoGenerated,
                        isConst,
                        mapWithOPERA,
                      },
                      i
                    ) => (
                      <tr key={i}>
                        <td>{sunAttribute}</td>
                        <td>{valueType}</td>
                        <td>{autoGenerated ? "true" : "false"}</td>
                        <td>{isConst ? "true" : "false"}</td>
                        <td>{mapWithOPERA && mapWithOPERA}</td>
                        <td>
                          <img
                            src={Trash}
                            alt="Delete"
                            onClick={() => handleDelete(sunAttribute)}
                          />

                          <img
                            src={Edit}
                            alt="Edit"
                            onClick={() =>
                              handleEdit(sunAttribute, valueType, i)
                            }
                          />
                        </td>
                      </tr>
                    )
                  )}
                </table>
              </div>
            </div>
          </div>
        </div>
      </main>
    </div>
  );
};
export default mappingOperaToSunHDR;
