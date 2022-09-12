#region MortgageCalculatorSolution (MarketHomeValue)
using System;

namespace MortgageCalculatorSolution
{
    public class MarketHomeValue
    {
        static void Main(string[] args)
        {
            //Market Home Value (Principle)
            {
                Console.WriteLine("What is the price of your home?: ");
                uint priceOfHome;
                while (true)
                {
                    string userInput = Console.ReadLine();
                    if (uint.TryParse(userInput, out uint priceofhome))
                    {
                        priceOfHome = priceofhome;
                        Console.WriteLine("\nThe price of your home is $" + priceofhome);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid value, please enter an unsigned integer from 0 - 4294967295 as a whole number only.");
                        continue;
                    }
                }
                #endregion

                #region Loan Amount
                //Loan Amount
                Console.WriteLine("\nWhat is the requested loan amount?: ");
                uint loanAmount;
                while (true)
                {
                    string fuserinput = Console.ReadLine();
                    if (uint.TryParse(fuserinput, out uint loanamount))
                    {
                        loanAmount = loanamount;
                        Console.WriteLine("\nYour total loan amount is for $" + loanamount);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid value, please enter an unsigned integer from 0 - 4294967295 as a whole number only.");
                        continue;
                    }
                }
                #endregion

                #region DownPayment
                //Down Payment
                Console.WriteLine("\nWhat is the down payment amount?: ");
                uint downPayment;
                while (true)
                {
                    string suserInput = Console.ReadLine();
                    if (uint.TryParse(suserInput, out uint downpayment))
                    {
                        downPayment = downpayment;
                        Console.WriteLine("\nThe down payment for your home is $" + downpayment);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid value, please enter an unsigned integer from 0 - 4294967295 as a whole number only.");
                        continue;
                    }
                }
                #endregion

                #region Loan Term
                //Loan Term
                Console.WriteLine("\nWill this loan term be for 15 or 30 years?");
                uint loanTerm;
                while (true)
                {
                    string tuserInput = Console.ReadLine();
                    if (uint.TryParse(tuserInput, out uint loanterm))
                    {
                        loanTerm = loanterm;
                        Console.WriteLine("\nThe loan term for your home is for " + loanterm + " years");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Inavalid value, please enter either 15 or 30.");
                        continue;
                    }

                }
                #endregion

                #region Interest Rate
                //Interest Rate
                Console.WriteLine("\nWhat is the interest rate?");
                double interestRate;
                while (true)
                {
                    string tuserInput = Console.ReadLine();
                    if (double.TryParse(tuserInput, out double interestrate))
                    {
                        interestRate = (interestrate / 100);
                        Console.WriteLine("\nYour Interest rate is: " + interestrate + "%");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid value, please enter only a decimal value.");
                        continue;
                    }
                }
                #endregion

                #region Calculate
                double monthInterestRate = interestRate / 12;
                double firstMathPow = Math.Pow(1 + monthInterestRate, loanTerm * 12);
                double secondMathPow = (Math.Pow(1 + monthInterestRate, loanTerm * 12) - 1);
                double total = (loanAmount - downPayment) * monthInterestRate * firstMathPow / secondMathPow;
                Console.WriteLine("\nThis is your estimated monthly loan payment excluding fee's and taxes:");
                Console.WriteLine("$" + total);
                double originationFee = (.01 * loanAmount);
                Console.WriteLine("\nOrigination fee is $" + originationFee);
                double fee = 2500;
                Console.WriteLine("Fee's for approximate taxes and closing costs on sale are $" + fee);
                double newLoanamount;
                newLoanamount = loanAmount + originationFee + fee;
                Console.WriteLine("\nYour new total loan amount with taxes and fee's included is $" + newLoanamount);
                
                Console.WriteLine("\nWhat is the market value of your home?");
                uint marketValue;
                while (true)
                {
                    string euserInput = Console.ReadLine();
                    if (uint.TryParse(euserInput, out uint marketvalue))
                    {
                        marketValue = marketvalue;
                        Console.WriteLine("\nThe market value for your home is: $" + marketvalue);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid value, please enter an unsigned integer from 0 - 4294967295 as a whole number only.");
                        continue;
                    }
                }
                double equity = (Convert.ToDouble(marketValue) - Convert.ToDouble(loanAmount) + Convert.ToDouble(downPayment)) / Convert.ToDouble(marketValue) * 100d;
                Console.WriteLine("\nThe value of equity on your home is " + equity + "%");
                
                double loanInsurance;
                    if (equity <= 10d)
                    {
                        Console.WriteLine("\nYou do require loan insurance");
                        loanInsurance = (.01d * loanAmount) / loanTerm;
                        Console.WriteLine("\nLoan insurance will be $" + loanInsurance + " per year, totaling $" + (loanInsurance * loanTerm) + "at the end of the loan term.");
                    }
                    else
                    {
                        Console.WriteLine("\nYou do not require loan insurance.");
                    }
                    
                Console.WriteLine("\nWhat is the yearly HOA fee?");
                double hoaFee;
                while (true)
                {
                    string nuserinput = Console.ReadLine();
                    if (double.TryParse(nuserinput, out double hoafee))
                    {
                        Console.WriteLine("\nYour HOA fee amount is $" + hoafee);
                        hoaFee = (hoafee / 12) + total;
                        Console.WriteLine("\nYour new monthly payment included with HOA fee's is $" + hoaFee);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("\nInvalid value please enter a numerical value");
                        continue;
                    }
                }
                Console.WriteLine("\nWe will now calculate Escrow, property tax(1.25%) and homeowners insurance(.75%)");
                double propertyTax = (.0125d / 12) * marketValue;
                double homeownersInsurance = (.0075d / 12) * marketValue;
                double escrow = propertyTax + homeownersInsurance;
                double newMonthlypayment = escrow + total;
                Console.WriteLine("\nNew monthly payment is $" + newMonthlypayment);
                
                Console.WriteLine("\nWhat is your monthly income?");
                double monthlyIncome;
                while (true)
                {
                    string luserinput = Console.ReadLine();
                    if (double.TryParse(luserinput, out double monthlyincome))
                    {
                        Console.WriteLine("\nYour monthly income is $" + monthlyincome);
                        monthlyIncome = monthlyincome;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("\nInvalid value please enter a numerical value");
                        continue;
                    }
                }
                if (monthlyIncome*.25d >= newMonthlypayment)
                {
                    Console.WriteLine("\nYou are approved");
                }
                else
                {
                    Console.WriteLine("\nWe cannot approve your loan at this time, we suggest placing more money down and/or buying a more affordable home");
                }

                }
                #endregion
            }
        }
    }

               