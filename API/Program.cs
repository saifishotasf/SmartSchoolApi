using Contracts.DataContracts;
using Contracts.DomainContracts;
using Data;
using Domain;
using Microsoft.EntityFrameworkCore;
using NLog;
using Utility.GlobalErrorHandling;
using Utility.LoggerService;

var builder = WebApplication.CreateBuilder(args);

//cros
builder.Services.AddCors(p => p.AddPolicy("corsapp", builder =>
{
    builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
}));

LogManager.LoadConfiguration(String.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));

//Logger Service
builder.Services.AddSingleton<ILoggerManager, LoggerManager>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContextPool<ApplicationDbContext>(op => op.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionString")));
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IInstitute, InstituteDomain>();
builder.Services.AddScoped<IInstituteData, InstituteData>();

builder.Services.AddScoped<IUser, UserDomain>();
builder.Services.AddScoped<IUserData, UserData>();

builder.Services.AddScoped<IRole, RoleDomain>();
builder.Services.AddScoped<IRoleData, RoleData>();

builder.Services.AddScoped<IStandard, StandardDomain>();
builder.Services.AddScoped<IStandardData, StandardData>();

builder.Services.AddScoped<ISubject, SubjectDomain>();
builder.Services.AddScoped<ISubjectData, SubjectData>();

builder.Services.AddScoped<IStudent, StudentDomain>();
builder.Services.AddScoped<IStudentData, StudentData>();

builder.Services.AddScoped<IDivision, DivisionDomain>();
builder.Services.AddScoped<IDivisionData, DivisionData>();

builder.Services.AddScoped<IStudentAttendance, StudentAttendanceDomain>();
builder.Services.AddScoped<IStudentAttendanceData, StudentAttendanceData>();

builder.Services.AddScoped<IAttendanceReport, AttendanceReportDomain>();
builder.Services.AddScoped<IAttendanceReportData, AttendanceReportData>();

builder.Services.AddScoped<IUserReport, UserReportDomain>();
builder.Services.AddScoped<IUserReportData, UserReportData>();

builder.Services.AddScoped<ITimeTableManagement,TimeTableManagementDomain>();
builder.Services.AddScoped<ITimeTableManagementData, TimeTableManagementData>();

builder.Services.AddScoped<IFeesManagement, FeesManagementDomain>();
builder.Services.AddScoped<IFeesManagementData, FeesManagementData>();

builder.Services.AddScoped<IStaffAttendance, StaffAttendanceDomain>();
builder.Services.AddScoped<IStaffAttendanceData,StaffAttendanceData>();

builder.Services.AddScoped<IDashboard, DashboardDomain>();
builder.Services.AddScoped<IDashboardData, DashboardData>();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("corsapp");

app.UseAuthorization();

//app.UseMiddleware<GlobalExceptionHandlerMiddleware>();

app.MapControllers();

app.Run();
