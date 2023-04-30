using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Business.Dtos;
using Web.Cryptoutils;
using Web.Cryptoutils.Commands;

namespace Web.Business.Operations
{
    public class EllipticCurveHandler : Handler<EllipticCurveParameters>
    {
        public EllipticCurveHandler(IConsoleApp consoleApp) : base(consoleApp)
        {
        }

        public override async Task<string> HandleAsync(EllipticCurveParameters parameters)
        {
            Command command = null;

            if (parameters.Normal != null)
            {
                if (parameters.Normal.Sum != null)
                {
                    command = new Cryptoutils.Commands.EllipticCurve.Normal.SumCommand(
                        parameters.Normal.Sum.CurveA,
                        parameters.Normal.Sum.CurveB,
                        parameters.Normal.Sum.CurvePrime,
                        parameters.Normal.Sum.FirstPoint,
                        parameters.Normal.Sum.SecondPoint
                    );
                }
                else if(parameters.Normal.Alignson != null)
                {
                    command = new Cryptoutils.Commands.EllipticCurve.Normal.AlignsonCommand(
                        parameters.Normal.Alignson.CurveA,
                        parameters.Normal.Alignson.CurveB,
                        parameters.Normal.Alignson.CurvePrime,
                        parameters.Normal.Alignson.Point
                    );
                }
            }
            else if(parameters.Advanced != null)
            {
                if (parameters.Advanced.Sum != null)
                {
                    command = new Cryptoutils.Commands.EllipticCurve.Advanced.SumCommand(
                        parameters.Advanced.Sum.CurveA_G,
                        parameters.Advanced.Sum.CurveB_G,
                        parameters.Advanced.Sum.PolynomialBinary,
                        parameters.Advanced.Sum.IrreduciblePolynomialBinary,
                        parameters.Advanced.Sum.N,
                        parameters.Advanced.Sum.FirstPoint,
                        parameters.Advanced.Sum.SecondPoint
                    );
                }
                else if (parameters.Advanced.Multiply != null)
                {
                    command = new Cryptoutils.Commands.EllipticCurve.Advanced.MultiplyCommand(
                        parameters.Advanced.Multiply.CurveA_G,
                        parameters.Advanced.Multiply.CurveB_G,
                        parameters.Advanced.Multiply.PolynomialBinary,
                        parameters.Advanced.Multiply.IrreduciblePolynomialBinary,
                        parameters.Advanced.Multiply.N,
                        parameters.Advanced.Multiply.Point,
                        parameters.Advanced.Multiply.Scalar
                    );
                }
                else if (parameters.Advanced.Alignson != null)
                {
                    command = new Cryptoutils.Commands.EllipticCurve.Advanced.AlignsonCommand(
                        parameters.Advanced.Alignson.CurveA_G,
                        parameters.Advanced.Alignson.CurveB_G,
                        parameters.Advanced.Alignson.PolynomialBinary,
                        parameters.Advanced.Alignson.IrreduciblePolynomialBinary,
                        parameters.Advanced.Alignson.N,
                        parameters.Advanced.Alignson.Point
                    );
                }
            }

            return await command?.ExecuteWithParametersPrintedAsync(this.consoleApp);
        }
    }
}
