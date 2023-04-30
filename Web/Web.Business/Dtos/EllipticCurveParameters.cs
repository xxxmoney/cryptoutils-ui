using FoolProof.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Cryptoutils.Models;

namespace Web.Business.Dtos
{
    public class EllipticCurveParameters
    {
        public EllipticCurveNormalParameters Normal { get; set; }
        public EllipticCurveAdvancedParameters Advanced { get; set; }
    }

    public class EllipticCurveNormalParameters
    {
        public EllipticCurveNormalSumParameters Sum { get; set; }
        public EllipticCurveNormalAlignsonParameters Alignson { get; set; }
    }
    public class EllipticCurveNormalSumParameters
    {
        [Required]
        public long CurveA { get; set; }
        [Required]
        public long CurveB { get; set; }
        [Required]
        public long CurvePrime { get; set; }
        [Required]
        public Point FirstPoint { get; set; }
        [Required]
        public Point SecondPoint { get; set; }
    }
    public class EllipticCurveNormalAlignsonParameters
    {
        [Required]
        public long CurveA { get; set; }
        [Required]
        public long CurveB { get; set; }
        [Required]
        public long CurvePrime { get; set; }
        [Required]
        public Point Point { get; set; }
    }

    public class EllipticCurveAdvancedParameters
    {
        public EllipticCurveAdvancedSumParameters Sum { get; set; }
        public EllipticCurveAdvancedMultiplyParameters Multiply { get; set; }
        public EllipticCurveAdvancedAlignsonParameters Alignson { get; set; }
    }
    public class EllipticCurveAdvancedSumParameters
    {
        [Required]
        public string CurveA_G;
        [Required]
        public string CurveB_G;
        [Required]
        public string PolynomialBinary;
        [Required]
        public string IrreduciblePolynomialBinary;
        [Required]
        public long N;
        [Required]
        public CustomPoint FirstPoint;
        [Required]
        public CustomPoint SecondPoint;
    }
    public class EllipticCurveAdvancedMultiplyParameters
    {
        [Required]
        public string CurveA_G;
        [Required]
        public string CurveB_G;
        [Required]
        public string PolynomialBinary;
        [Required]
        public string IrreduciblePolynomialBinary;
        [Required]
        public long N;
        [Required]
        public CustomPoint Point;
        [Required]
        public long Scalar;
    }
    public class EllipticCurveAdvancedAlignsonParameters
    {
        [Required]
        public string CurveA_G;
        [Required]
        public string CurveB_G;
        [Required]
        public string PolynomialBinary;
        [Required]
        public string IrreduciblePolynomialBinary;
        [Required]
        public long N;
        [Required]
        public CustomPoint Point;
    }
}
